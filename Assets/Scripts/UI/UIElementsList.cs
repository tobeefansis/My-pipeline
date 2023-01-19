using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIElementsList<K> : MonoBehaviour where K : MonoBehaviour
    {
        public List<K> Items
        {
            get => items;
            set => items = value;
        }

        [SerializeField] private List<UIHolder<K>> itemHolders = new List<UIHolder<K>>();
        [SerializeField] private List<K> items = new List<K>();
        [SerializeField] private Transform context;
        [SerializeField] private UIHolder<K> prefab;
        [SerializeField] private GameObject isEmptyMessage;
       public void Refresh()
        {
            isEmptyMessage.SetActive(items.Count==0);
            for (var index = 0; index < items.Count; index++)
            {
                var item = items[index];
                if (index < itemHolders.Count)
                {
                    itemHolders[index].Refresh(item);
                    itemHolders[index].gameObject.SetActive(true);
                }
                else
                {
                    var newItem = Instantiate(prefab,context);
                    newItem.Refresh(item);
                    itemHolders.Add(newItem);
                }
                
            }

            if (itemHolders.Count>items.Count)
            {
                for (var index = items.Count; index < itemHolders.Count; index++)
                {
                    var item = itemHolders[index];
                    item.gameObject.SetActive(false);
                }
            }
        }


        public abstract void Initialize();
        public abstract void SortBy();
    }
}
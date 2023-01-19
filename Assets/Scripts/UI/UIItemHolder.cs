
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIItemHolder : UIHolder<Item>
    {
        [SerializeField] private Image image;

        
        public void Select()
        {
            UIItemInfoReviewer.I.ShowItemInfo(Item);
        }
        public override void Refresh(Item item)
        {
            base.Refresh(item);
            image.sprite = item.ItemImage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIHolder<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T item;

        public T Item
        {
            get => item;
            set => item = value;
        }

        public virtual void Refresh(T item)
        {
            this.item = item;
        }

    }
}
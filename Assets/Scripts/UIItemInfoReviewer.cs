using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemInfoReviewer : Singleton<UIItemInfoReviewer>
{
    [SerializeField] private UIItemInfoHolder popupItemInfoHolder;
    [SerializeField] private UIItemInfoHolder inventoryItemInfoHolder;
    public void ShowItemInfo(Item item)
    {
        if (inventoryItemInfoHolder.gameObject.activeInHierarchy)
        {
            inventoryItemInfoHolder?.gameObject.SetActive(true);

            inventoryItemInfoHolder?.Refresh(item);
        }
        else
        {
            popupItemInfoHolder?.gameObject.SetActive(true);
            popupItemInfoHolder?.Refresh(item);

        }
    }
}

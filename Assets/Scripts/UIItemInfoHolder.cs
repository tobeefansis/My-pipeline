using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfoHolder : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    [SerializeField] private TextMeshProUGUI itemNameHolder;
    [SerializeField] private TextMeshProUGUI itemDescriptionHolder;
    [SerializeField] private UIItemParameters itemParametersHolder;

    [SerializeField] private GameObject isNotSelectedItem;
    public void Refresh(Item item)
    {
        isNotSelectedItem.SetActive(item==null);
        
        itemImageHolder.gameObject.SetActive(item!=null);
        itemNameHolder.gameObject.SetActive(item!=null);
        itemDescriptionHolder.gameObject.SetActive(item!=null);
        itemParametersHolder.gameObject.SetActive(item!=null);
        
        if (item!=null)
        {
            itemImageHolder.sprite = item.ItemImage;
            itemNameHolder.text = item.ItemName;
            itemDescriptionHolder.text = item.ItemDescription;
            itemParametersHolder.Items = item.ItemParameters;
            itemParametersHolder.Refresh();
        }
    }

    private void OnEnable()
    {
        Refresh(null);
    }
}

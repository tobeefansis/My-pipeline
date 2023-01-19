using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Item : MonoBehaviour
{
    [SerializeField] private Sprite itemImage;
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private List<ItemParameter> itemParameters;

    public string ItemName
    {
        get => itemName;
        set => itemName = value;
    }

    public string ItemDescription
    {
        get => itemDescription;
        set => itemDescription = value;
    }

    public List<ItemParameter> ItemParameters
    {
        get => itemParameters;
        set => itemParameters = value;
    }

    public Sprite ItemImage
    {
        get => itemImage;
        set => itemImage = value;
    }

   
}
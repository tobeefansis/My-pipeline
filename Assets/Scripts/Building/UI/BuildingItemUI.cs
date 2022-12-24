using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BuildingItemUI : MonoBehaviour
{
    private Button _button;

    [SerializeField] private GameObject itemGameObject;
    private void Awake()
    {
        _button = GetComponent<Button>();
       // _button.onClick.AddListener(SetItem);
    }

   public void SetItem()
    {
        Debug.Log("sdfsdf");
        if (ObjectInstaller.InstanceExists)
        {
            ObjectInstaller.I.SetBuildItem(itemGameObject);
        }
    }
}
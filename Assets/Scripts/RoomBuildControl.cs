using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBuildControl : MonoBehaviour
{
    [SerializeField] private ObjectInstaller objectInstaller;

    public void OnStartBuild()
    {
        objectInstaller.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public void OnEndBuild()
    {
        objectInstaller.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
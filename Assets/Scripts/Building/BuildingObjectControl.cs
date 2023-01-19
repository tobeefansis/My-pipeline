using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Conveyor))]
public class BuildingObjectControl : MonoBehaviour, IPointerClickHandler
{
    private Conveyor _conveyor;
    public static float SpawnDirection;
    private void Awake()
    {
        _conveyor = GetComponent<Conveyor>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!PopupMenu.InstanceExists) return;

        PopupMenu.I.SetPosition(transform.position, this);
    }

    public void ObjectRotationRight()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 90, 0));
        SpawnDirection = transform.rotation.eulerAngles.y;
        Debug.Log(SpawnDirection);
        _conveyor.Init();
    }

    public void ObjectRotationLeft()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 90, 0));
        SpawnDirection = transform.rotation.eulerAngles.y;
        Debug.Log(SpawnDirection);
        _conveyor.Init();
    }

    public void ObjectDestroy()
    {
        if (ObjectInstaller.InstanceExists)
        {
            ObjectInstaller.I.Builds.Remove(gameObject);
        }
        Destroy(gameObject);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupMenu : Singleton<PopupMenu>
{
   private Camera cam;
   [SerializeField] private BuildingObjectControl currentBuildingObjectControl;
   protected override void Awake()
   {
      base.Awake();
      cam=Camera.main;
      Diselect();
   }

   public void SetPosition(Vector3 worldPosition,BuildingObjectControl buildingObjectControl)
   {
      gameObject.SetActive(true);
      transform.position = cam.WorldToScreenPoint(worldPosition);
      currentBuildingObjectControl = buildingObjectControl;
   }

   public void Diselect()
   {
      gameObject.SetActive(false);
      currentBuildingObjectControl = null;
   }

   public void ObjectRotationRight()
   {
      if (!currentBuildingObjectControl)return;
      currentBuildingObjectControl.ObjectRotationRight();
   }
   public void ObjectRotationLeft()
   {
      if (!currentBuildingObjectControl)return;
      currentBuildingObjectControl.ObjectRotationLeft();

   }
   public void ObjectDestroy()
   {
      if (!currentBuildingObjectControl)return;
      currentBuildingObjectControl.ObjectDestroy();
      Diselect();
   }
}

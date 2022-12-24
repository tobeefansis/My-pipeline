using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InstallationPositionLocator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    private Camera cam;

    [SerializeField] private int greedCellValue;
    [SerializeField] private float yPosition;
    [SerializeField] private UnityEvent<Vector3> onStartInstallPosition;
    [SerializeField] private UnityEvent<Vector3> onEndInstallPosition;
    [SerializeField] private UnityEvent<Vector3> onInstallingPosition;
    [SerializeField] private Vector2Int minPosition;
    [SerializeField] private Vector2Int maxPosition;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (PopupMenu.InstanceExists)
        {
            PopupMenu.I.Diselect();
        }
        var position = ScreenToWorldPoint(eventData.position);
     
        onStartInstallPosition.Invoke(position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var position = ScreenToWorldPoint(eventData.position,false);
        onEndInstallPosition.Invoke(position);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        var position = ScreenToWorldPoint(eventData.position);
        onInstallingPosition.Invoke(position);
    }

    Vector3 ScreenToWorldPoint(Vector3 position, bool checkPosition = true)
    {
        var groundPlayne = new Plane(Vector3.up, Vector3.zero);
        var ray = cam.ScreenPointToRay(position);
        if (!groundPlayne.Raycast(ray, out var pos)) return Vector3.positiveInfinity;
        var worldPosition = ray.GetPoint(pos);
        var x = Mathf.RoundToInt(worldPosition.x);
        var y = Mathf.RoundToInt(worldPosition.z);
        if (!checkPosition) return new Vector3(x, yPosition, y);
        if (x<minPosition.x||y<minPosition.y||x>maxPosition.x||y>maxPosition.y)return Vector3.positiveInfinity;
        x = (int) Mathf.Clamp(x, minPosition.x, maxPosition.x);
        y = (int) Mathf.Clamp(y, minPosition.y, maxPosition.y);
        return new Vector3(x, yPosition, y);
    }
}
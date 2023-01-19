
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Map : MonoBehaviour
{
    [SerializeField] List<Location> locations = new List<Location>();

    [SerializeField] private int selectLocationIndex;
    [SerializeField] private Transform cam;
    [SerializeField] private float movementTime;
    [SerializeField] private UnityEvent<bool> onMovement;
    [SerializeField] private UIInventory inventory;
    void Start()
    {
        locations.Sort(Sort);
        selectLocationIndex = 0;
        Select();

    }

    public void Right()
    {
        selectLocationIndex++;
        if (selectLocationIndex>=locations.Count)
        {
            selectLocationIndex -= locations.Count;
        }
        Select();
    }
    public void Left()
    {
        selectLocationIndex--;
        if (selectLocationIndex<0)
        {
            selectLocationIndex += locations.Count;
        }

        Select();
    }
    public void Select() => Select(movementTime);
    public void Select(float time)
    {
        var pos = locations[selectLocationIndex].transform.position;
        onMovement.Invoke(false);
        inventory.Items = locations[selectLocationIndex].Items;
        inventory.Refresh();
        cam.DOMove(pos,movementTime).OnComplete(() =>
        {
            onMovement.Invoke(true);
        });
    }
    
    int Sort(Location t1, Location t2)
    {
        var t1x = t1.transform.position.x;
        var t2x = t2.transform.position.x;
        if (t1x > t2x) return 1;
        if (t1x < t2x) return -1;
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
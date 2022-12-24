using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlayingControl : MonoBehaviour
{
    [SerializeField] private List<PlayingObject> playingObjects = new List<PlayingObject>();
    [SerializeField] private List<GameObject> tempObjects = new List<GameObject>();
    [SerializeField] private Transform spawnParent;

    public void OnStartPlaying()
    {
        gameObject.SetActive(true);
        foreach (var playingObject in playingObjects)
        {
            var newObject = Instantiate(playingObject.SpawnPrefab, playingObject.SpawnPoint.position, Quaternion.identity, spawnParent);
            tempObjects.Add(newObject);
        }
    }

    public void OnEndPlaying()
    {
        foreach (var tempObject in tempObjects)
        {
            Destroy(tempObject);
        }
        tempObjects.Clear();
        gameObject.SetActive(false);
    }

    [Serializable]
    public class PlayingObject
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject spawnPrefab;

        public Transform SpawnPoint
        {
            get => spawnPoint;
            set => spawnPoint = value;
        }

        public GameObject SpawnPrefab
        {
            get => spawnPrefab;
            set => spawnPrefab = value;
        }
    }
}
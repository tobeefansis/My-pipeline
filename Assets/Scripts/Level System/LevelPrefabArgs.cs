
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefabArgs : MonoBehaviour
{
    [SerializeField] private List<RoomPlayingControl.PlayingObject> spawnPoints;
    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    public List<GameObject> Objects => objects;
    public List<RoomPlayingControl.PlayingObject> SpawnPoints => spawnPoints;
    
}

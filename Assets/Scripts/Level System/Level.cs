using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private string levelName;
    [SerializeField][Range(0,100)] private int progress;
    [SerializeField] GameObject prefab;

    public GameObject Prefab => prefab;
    public bool IsOpen => isOpen;
    public string LevelName => levelName;
    public float Progress => progress;
}

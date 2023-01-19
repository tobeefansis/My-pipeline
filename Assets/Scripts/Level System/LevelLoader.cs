using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : Singleton<LevelLoader>
{
    [SerializeField] private GameObject currentLevelPrefab;
    [SerializeField] private Level currentLevel;
    [SerializeField] private UnityEvent<LevelPrefabArgs> onLoadLevel;
    [SerializeField] private UnityEvent onClear;

    public void LoadLevel(Level level)
    {
        Clear();
        currentLevel = level;
        currentLevelPrefab = Instantiate(level.Prefab, transform);
        var args = currentLevelPrefab.GetComponent<LevelPrefabArgs>();
        onLoadLevel.Invoke(args);
    }

    public void Clear()
    {
        if (!currentLevelPrefab) return;
        Destroy(currentLevelPrefab);
        currentLevelPrefab = null;
        onClear.Invoke();
    }
}
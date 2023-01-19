using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ObjectInstaller : Singleton<ObjectInstaller>
{
    [SerializeField] private GameObject buildPrefab;
    [SerializeField] private GameObject currentGameObject;
    [SerializeField] private List<GameObject> builds = new List<GameObject>();
    [SerializeField] private float yPosition;
    [SerializeField] private Transform buildsParent;
    [SerializeField] private Vector2Int minPosition;
    [SerializeField] private Vector2Int maxPosition;

    public List<GameObject> Builds
    {
        get => builds;
        set => builds = value;
    }

    public void StartInstall(Vector3 position)
    {
        if (!gameObject.activeInHierarchy) return;
        if (position.x < minPosition.x || position.z < minPosition.y || position.x > maxPosition.x ||
            position.z > maxPosition.y)
        {
            return;
        }

        if (builds.Any(build => position == build.transform.position)) return;
        position.y = yPosition;

        var rotation = Quaternion.Euler(0, BuildingObjectControl.SpawnDirection, 0);
        currentGameObject = Instantiate(buildPrefab, position, rotation, buildsParent);
    }

    public void Clear()
    {
        foreach (Transform build in buildsParent.transform)
        {
            Destroy(build.gameObject);
        }
    }
    public void EndInstall(Vector3 position)
    {
        if (!gameObject.activeInHierarchy) return;
        if (currentGameObject == null) return;
        if (position == Vector3.positiveInfinity || builds.Any(build => position == build.transform.position))
        {
            Destroy(currentGameObject);
            return;
        }

        if (position.x < minPosition.x || position.z < minPosition.y || position.x > maxPosition.x ||
            position.z > maxPosition.y)
        {
            Destroy(currentGameObject);
            return;
        }

        position.y = yPosition;
        currentGameObject.transform.position = position;
        if (!PopupMenu.InstanceExists) return;

        PopupMenu.I.SetPosition(position, currentGameObject.GetComponent<BuildingObjectControl>());
        builds.Add(currentGameObject);
        currentGameObject = null;
    }

    public void Move(Vector3 position)
    {
        if (!gameObject.activeInHierarchy) return;
        if (currentGameObject == null) return;
        if (builds.Any(build => position == build.transform.position)) return;
        currentGameObject.transform.position = position;
    }

    public void UpdateLevel(LevelPrefabArgs args)
    {
        builds = new List<GameObject>(args.Objects);
    }

    public void SetBuildItem(GameObject gameObject)
    {
        buildPrefab = gameObject;
    }
}
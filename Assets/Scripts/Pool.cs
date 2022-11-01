using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
    public int maxAmount;
}

public class Pool : MonoBehaviour
{
    public static Pool instance;

    [SerializeField] private List<PoolItem> objects;

    private List<GameObject> pooledObjects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (PoolItem item in objects)
        {
            for (int i = 0; i < item.amount; i++)
            {
                InstantiateAndAddObjectToPool(item);
            }
        }
    }

    public GameObject Get(string objectTag)
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (obj.CompareTag(objectTag) && !obj.activeInHierarchy)
            {
                return obj;
            }
        }

        AddIfExpandable(objectTag);

        return null;
    }

    private void InstantiateAndAddObjectToPool(PoolItem item)
    {
        GameObject spawnedItem = Instantiate(item.prefab, transform, true);
        spawnedItem.SetActive(false);
        pooledObjects.Add(spawnedItem);
    }

    private void AddIfExpandable(string objectTag)
    {
        foreach (PoolItem item in objects)
        {
            var pooledObectsWithTag = GameObject.FindGameObjectsWithTag(objectTag);
            if (item.expandable && item.prefab.CompareTag(objectTag) && pooledObectsWithTag.Length < item.maxAmount)
            {
                InstantiateAndAddObjectToPool(item);
            }
        }
    }
}

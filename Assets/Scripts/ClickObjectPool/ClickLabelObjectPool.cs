using System.Collections.Generic;
using UnityEngine;

public class ClickLabelObjectPool : MonoBehaviour
{
    public static ClickLabelObjectPool SharedInstance;

    [SerializeField]
    private List<GameObject> pooledObjects;

    [SerializeField]
    private GameObject objectToPool;

    [SerializeField]
    private GameObject rootObject;

    [SerializeField]
    private int amountToPool;

    public void Awake()
    {
        SharedInstance = this;
    }

    public void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, rootObject.transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        return null;
    }
}

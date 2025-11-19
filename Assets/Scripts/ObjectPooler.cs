using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //This script generates a bunch of objects that are going to be used in our game but
    //lets us reuse those same objects rather than instantiating and deleting every time
    //we need to spawn meows or different NPCs
    public GameObject prefab;
    public int poolSize = 10;

    private List<GameObject> pool;

    private void InitializePool()
    {
        pool = new List<GameObject>();
        if (prefab.name.Contains("Fishmonger"))
        poolSize = 4;
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObj();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
            InitializePool();
        }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            //Checks for inactive object
            if (!obj.activeInHierarchy)
                return obj;
        }

        //if there are no inactive objects, then we need to create a new object
        return CreateNewObj();
    }

    private GameObject CreateNewObj()
    {
        while (pool.Count >= poolSize)
        {
            Destroy(pool.ElementAt(0));
        }
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }
    
    public void ClearList()
    {
        pool.Clear();
        GameObject[] remainingObjects = GameObject.FindGameObjectsWithTag("ObjectPool");
        foreach (GameObject obj in remainingObjects) { Destroy(obj); }



    }

}

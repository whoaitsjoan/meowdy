using System.Collections.Generic;
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
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }
    
    public void ClearList()
    {
        pool.Clear();
    }

}

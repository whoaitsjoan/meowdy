using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TitleCatSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> cats = new List<GameObject>();
    private float spawnInterval = 1.5f;
    public float numberSpawned = 0;
    public int catNum;
    public bool restart;
    void Start()
    {
        spawnInterval = 0.5f;
        restart = false;
        catNum = 0;
        for (int i = 0; i < cats.Count; i++)
        {
            cats[i].SetActive(false);
        }
        StartCoroutine(SpawnCatCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (numberSpawned < 6)
            StartCoroutine(SpawnCatCoroutine());
=======
        spawnInterval = 1.5f;
        if (restart)
        {
            //Debug.Log("a");
            //StartCoroutine(SpawnCatCoroutine());
            //restart = false;
        }
>>>>>>> Stashed changes
        
    }

    IEnumerator SpawnCatCoroutine()
    {
        while (numberSpawned < 6)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnCat();
            numberSpawned++;
            Debug.Log(numberSpawned);
        }
        if(numberSpawned > 6)
        {
            StopCoroutine(SpawnCatCoroutine());
        }
        
    }

    void SpawnCat()
    {
        GameObject cat = cats[catNum];
        cat.transform.position = transform.position;
        cat.SetActive(true);
        if(catNum < cats.Count)
        {
            catNum++;
        }
        if(catNum == cats.Count)
        {
            catNum = 0;
            restart = true;
        }
    }
}

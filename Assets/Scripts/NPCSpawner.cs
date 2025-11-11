using System.Collections;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnInterval;
    public float numberSpawned = 0;

    public ObjectPooler NPCPool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnNPCCoroutine());
    }
    
    IEnumerator SpawnNPCCoroutine()
    {
        while(numberSpawned < 2)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject();
            numberSpawned++;
        }
    }

    void SpawnObject()
    {
        GameObject NPC = NPCPool.GetPooledObject();
        NPC.transform.position = transform.position;
        NPC.SetActive(true);
    }

    
}

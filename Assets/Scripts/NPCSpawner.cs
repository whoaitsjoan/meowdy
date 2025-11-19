using System.Collections;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnInterval;
    public float numberSpawned = 0;

    public ObjectPooler NPCPool, CatLoverPool, CatHaterPool, DobbyPool, PiggiePool, FishmongerPool;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnNPCCoroutine(1));
    }

    public void NewSpawn(int gameLevel)
    {
        numberSpawned = 0;
        StartCoroutine(SpawnNPCCoroutine(gameLevel));
    }
    
    IEnumerator SpawnNPCCoroutine(int gameLevel)
    {
        
        while(numberSpawned < 1)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnObject(gameLevel);
            numberSpawned++;
            yield return new WaitForSeconds(spawnInterval);
            
        }
        numberSpawned--;
    }

    void SpawnObject(int gameLevel)
    {
        GameObject NPC = new GameObject();
        if (gameLevel == 1)
        //at the start of the game, it's just the regular NPCs showing up, so this works normally
        NPC = NPCPool.GetPooledObject();
        else if (gameLevel == 2)
        //this now adds in the dogs and cat lovers, so a 1-4 range
        switch (Random.Range(1,5))
            {
             case 1: NPC = NPCPool.GetPooledObject(); break;
             case 2: NPC = CatLoverPool.GetPooledObject(); break;
             case 3: NPC = DobbyPool.GetPooledObject(); break;
             case 4: NPC = PiggiePool.GetPooledObject(); break;   
            }
        else if (gameLevel == 3)
        //now we can use every object pool to spawn our next NPC
        switch (Random.Range(1,7))
            {
             case 1: NPC = NPCPool.GetPooledObject(); break;
             case 2: NPC = CatLoverPool.GetPooledObject(); break;
             case 3: NPC = DobbyPool.GetPooledObject(); break;
             case 4: NPC = PiggiePool.GetPooledObject(); break;   
             case 5: NPC = CatHaterPool.GetPooledObject(); break;
             case 6: if (ScoreTracker.instance.fishCollected != 4)
             NPC = FishmongerPool.GetPooledObject(); 
             break;
            }

        NPC.transform.position = transform.position;
        NPC.SetActive(true);
    }

    
}

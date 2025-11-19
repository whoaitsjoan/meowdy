using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public Transform spawnParent;
    private Transform[] spawnPoints;
    private int currentSpawnPoint;
    private int gameLevel = 1;

    private int NPCLimit = 6;

    public UnityEvent spawnLevel1, spawnLevel2, spawnLevel3;

    private List<StateManager> activeNPCs = new(); 
    void Awake()
    {
        //Singleton method
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            

        }
        else if (instance != this)
        {
            //instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            

        }
    }
    public Transform GetCurrentWaypoint() { return spawnPoints[currentSpawnPoint]; }
    void Start()
    {
        spawnPoints = new Transform[spawnParent.transform.childCount];
        //each waypoint is set up in this array to be cycled through in sequence for where NPCs can stop
        for (int i = 0; i < spawnParent.transform.childCount; i++)
            spawnPoints[i] = spawnParent.transform.GetChild(i);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameLevel != 3)
        CheckTime();
    }

    void CheckTime()
    {
        if (Time.timeSinceLevelLoad >= 1.5f && gameLevel == 1)
        gameLevel++;
        else if (Time.timeSinceLevelLoad >= 3f && gameLevel == 2)
        gameLevel++;

    }

    public void AddNPC(StateManager state)
    {
        activeNPCs.Add(state);
    }

    public void UpdateSpawns(StateManager state)
    {
        activeNPCs.Remove(state);
        DetermineNextSpawn();

    }

    public void DetermineNextSpawn()
    {
        if (activeNPCs.Count >= NPCLimit)
        return;

        Transform availableSpawn = spawnPoints.First(i => i.GetComponent<NPCSpawner>().numberSpawned == 0);
        availableSpawn.GetComponent<NPCSpawner>().NewSpawn(gameLevel);


    }
}

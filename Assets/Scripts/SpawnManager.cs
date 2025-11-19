using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public Transform spawnParent;
    private Transform[] spawnPoints;
    private int currentSpawnPoint;
    private int gameLevel = 1;

    public UnityEvent newSpawn;

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
        

    }

    public void AddNPC(StateManager state)
    {
        activeNPCs.Add(state);
    }

    public void UpdateSpawns(StateManager state)
    {
        activeNPCs.Remove(state);
        newSpawn.Invoke();

    }

    public void DetermineNextSpawn()
    {
        
    }
}

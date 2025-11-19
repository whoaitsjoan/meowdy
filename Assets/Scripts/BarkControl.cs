using System.Collections.Generic;
using UnityEngine;

public class BarkControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<AudioClip> barks = new List<AudioClip>();
    public StateManager stateManager;
    public AudioSource dogMouth;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.stateCurrent == "NPCAngryState")
        {
            int rand = Random.Range(0, barks.Count);
            dogMouth.clip = barks[rand];
            dogMouth.Play();

        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private StateManager NPCStateManager = new StateManager();

    public static List<NPC> NPCList = new List<NPC>();

    public enum NPCType
    {
        Child,
        CatLover,
        DogLover,
        Dog,
        Fishmonger,
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (Transform child in collision.transform)
        {
            if (child.gameObject.name.Contains("MeowGrazeRange"))
                NPCStateManager.SwitchState(NPCStateManager.QuestioningState);
        }
        if (collision.CompareTag("Meow"))
            NPCStateManager.SwitchState(NPCStateManager.AttentionState);

        else if (collision.CompareTag("Wall"))
            gameObject.SetActive(false);

    }
}

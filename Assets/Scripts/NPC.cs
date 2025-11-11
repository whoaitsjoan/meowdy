using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private StateManager NPCStateManager;

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

    
   /* void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (Transform child in collision.transform)
        {
            if (child.gameObject.name.Contains("MeowGrazeRange"))
            {
                Debug.Log("Graze!");
                NPCStateManager.SwitchState(NPCStateManager.QuestioningState);
            }
        }
        if (collision.CompareTag("Meow"))
        {
            Debug.Log("Collision!");
            NPCStateManager.SwitchState(NPCStateManager.AttentionState);
            }

        else if (collision.CompareTag("Wall"))
            gameObject.SetActive(false);

    }
    */
}

using UnityEngine;

public class NPCWalkingState : BaseState
{
    
    public override void EnterState(StateManager state)
    {
        Debug.Log("You are in the walking state!");
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(3,0,0));
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {

    }

    public override void OnTriggerEnter2D(StateManager state, Collider2D other)
    {
        foreach (Transform child in other.transform)
        {
            if (child.gameObject.name.Contains("MeowGrazeRange"))
            {
                Debug.Log("Graze!");
                state.SwitchState(state.QuestioningState);
            }
        }
        if (other.CompareTag("Meow"))
        {
            Debug.Log("Collision!");
            state.SwitchState(state.AttentionState);
        }
    }
    

    public override void OnTriggerStay2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerExit2D(StateManager state, Collider2D other)
    {
        
    }
}

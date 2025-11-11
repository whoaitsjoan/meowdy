using UnityEngine;

public class NPCWalkingState : BaseState
{
    
    public override void EnterState(StateManager state)
    {
        Debug.Log("You are in the walking state!");
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.right);
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {

    }

    public override void OnTriggerEnter2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerStay2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerExit2D(StateManager state, Collider2D other)
    {
        
    }
}

using UnityEngine;

public class NPCWalkingState : BaseState
{
    
    public override void EnterState(StateManager state)
    {
        state.IsTransitioningState = false;
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        Transform t = state.GetComponent<Transform>();
        rb.AddForce(Vector3.zero);
        if (t.position.x < 0 && t.position.y > 0)
        {
            rb.AddForce(new Vector3(20, 0, 0));
        }
            
        else if (t.position.x > 10)
        {
            state.transform.localScale = new Vector3(state.transform.localScale.x *-1, state.transform.localScale.y, state.transform.localScale.z); 
           rb.AddForce(new Vector3(-20, 0, 0)); 
        }
            
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {

    }

    public override void OnTriggerEnter2D(StateManager state, Collider2D other)
    {    
        if (other.CompareTag("Meow") && !state.IsTransitioningState)
        {
            state.IsTransitioningState = true;
            state.SwitchState(state.AttentionState);
        }
        else
        {
            foreach (Transform child in other.transform)
            {
                if (child.gameObject.name.Contains("MeowGrazeRange") && !state.IsTransitioningState)
                {
                    Debug.Log("Graze!");
                    state.IsTransitioningState = true;
                    state.SwitchState(state.QuestioningState);
                }
            }
        }
    }
    

    public override void OnTriggerStay2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerExit2D(StateManager state, Collider2D other)
    {
        
    }
}

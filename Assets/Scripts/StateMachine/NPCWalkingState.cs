using UnityEngine;

public class NPCWalkingState : BaseState
{
    Rigidbody2D rb;
    
    public override void EnterState(StateManager state)
    {
        state.IsTransitioningState = false;
        rb = state.GetComponent<Rigidbody2D>();
        Transform t = state.GetComponent<Transform>();
        rb.linearVelocity = Vector3.zero;
        if (t.position.x < 0)
        {
            //og 20
            rb.AddForce(new Vector3(85, 0, 0));
        }
            
        else if (t.position.x > 10)
        {
            state.transform.localScale = new Vector3(state.transform.localScale.x *-1, state.transform.localScale.y, state.transform.localScale.z); 
           rb.AddForce(new Vector3(-85, 0, 0)); 
        }
        SpawnManager.instance.AddNPC(state);
            
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {
        if (PauseController.IsGamePaused)
            return;
       /* if (rb.linearVelocity.x == 0 && !state.IsTransitioningState)
        {
        rb.AddForce(new Vector3(1,0,0));
        state.IsTransitioningState = true;
        EnterState(state);
        }*/
    }

    public override void OnTriggerEnter2D(StateManager state, Collider2D other)
    {    
        if (other.CompareTag("Meow") && !state.IsTransitioningState)
        {
            if (state.gameObject.name.Contains("Dobby") || state.gameObject.name.Contains("Piggie") || state.gameObject.name.Contains("CatHater"))
            {
            state.IsTransitioningState = true;
            state.SwitchState(state.AngryState); 
            
            }
            else 
            {
            state.IsTransitioningState = true;
            state.SwitchState(state.AttentionState); 
            }
        }
        else
        {
            foreach (Transform child in other.transform)
            {
                if (state.gameObject.name.Contains("Dobby") || state.gameObject.name.Contains("Piggie") || state.gameObject.name.Contains("CatHater"))
                return;

                else if (child.gameObject.name.Contains("MeowGrazeRange") && !state.IsTransitioningState)
                {
                    Debug.Log("Graze!");
                    state.IsTransitioningState = true;
                    state.SwitchState(state.QuestioningState);
                }
            }
        }

        if (other.CompareTag("Wall") && !state.IsTransitioningState)
        {
            state.IsTransitioningState = true;
            SpawnManager.instance.UpdateSpawns(state);
            state.gameObject.SetActive(false);
        }

    }
    

    public override void OnTriggerStay2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerExit2D(StateManager state, Collider2D other)
    {
        
    }
}

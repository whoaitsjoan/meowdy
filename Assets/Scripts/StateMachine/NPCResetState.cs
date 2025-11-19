using UnityEngine;

public class NPCResetState : BaseState
{
    Rigidbody2D rb;
    public override void EnterState(StateManager state)
    {
        state.IsTransitioningState = false;
        Debug.Log("Reset State!");
        rb = state.GetComponent<Rigidbody2D>();
        Transform t = state.GetComponent<Transform>();
        if (t.position.x < 0)
        {
            //was 20
            rb.AddForce(new Vector3(85, 40, 0));
        }
         else if (t.position.x > 0)
        {
           
            //was 20
           rb.AddForce(new Vector3(-85, 40, 0));
        }

        if (state.gameObject.name.Contains("Fishmonger"))
        state.transform.GetChild(3).gameObject.SetActive(false);
        else
        {
        state.transform.GetChild(4).gameObject.SetActive(false);
        state.transform.GetChild(5).gameObject.SetActive(false);
        }
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {
        if (PauseController.IsGamePaused)
            return;
        Transform target = WaypointController.instance.GetCurrentWaypoint();
        if (rb.linearVelocity.x == 0 && !(Vector2.Distance(state.transform.position, target.position) < 0.1f))
        {
        rb.AddForce(new Vector3(1,0,0));
        state.IsTransitioningState = true;
        EnterState(state);
        }

    }
    
    public override void OnTriggerEnter2D(StateManager state, Collider2D other)
    {
        if (other.CompareTag("Wall") && !state.IsTransitioningState)
        {
            state.IsTransitioningState = true;
            SpawnManager.instance.UpdateSpawns(state);
            state.gameObject.SetActive(false);
            state.SwitchState(state.WalkingState);
        }
    }

    public override void OnTriggerStay2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerExit2D(StateManager state, Collider2D other)
    {
        
    }

}

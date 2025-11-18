using UnityEngine;

public class NPCAttentionState : BaseState
{
    private float moveSpeed = 2f;
    private bool isWaiting;

    public override void EnterState(StateManager state)
    {
        Debug.Log(state.GetCurrentState().ToString());
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.zero);
        isWaiting = false;

        //This toggles the exclamation point as on while the attention state is active
        state.transform.GetChild(4).gameObject.SetActive(true);
        
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {
        if (PauseController.IsGamePaused || isWaiting)
            return;
        
        

        MoveToWaypoint(state);
    }


    void MoveToWaypoint(StateManager state)
    {
       
        Transform target = WaypointController.instance.GetCurrentWaypoint();
        state.transform.position = Vector2.MoveTowards(state.transform.position, target.position, moveSpeed * Time.deltaTime);
        WaypointController.instance.NextWaypoint();

        if (Vector2.Distance(state.transform.position, target.position) < 0.1f)
        {
           isWaiting = true;
           WaypointController.instance.WaitAtWaypoint(state);
           WaypointController.instance.WaypointCollision(state);
        }
    }

    
    public override void OnTriggerEnter2D(StateManager state, Collider2D other)
    {
        /*if (other.CompareTag("Waypoint"))
        {
            Debug.Log("Collision check!");
            //NPCcollider = state.GetComponent<Collider2D>();
            WaypointController.instance.WaypointCollision(state);
        }*/
    }

    public override void OnTriggerStay2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerExit2D(StateManager state, Collider2D other)
    {
        
    }

}

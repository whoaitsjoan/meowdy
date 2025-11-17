using UnityEngine;

public class NPCAttentionState : BaseState
{

    private float moveSpeed = 2f;
    private bool isWaiting;

    
    public override void EnterState(StateManager state)
    {
        Debug.Log("This is the attention state!");
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        Transform t = state.GetComponent<Transform>();
        rb.AddForce(Vector3.zero);
        isWaiting = false;


        state.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log("Exclamation on!");
        
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

        if (Vector2.Distance(state.transform.position, target.position) < 0.1f)
        {
           isWaiting = true;
           WaypointController.instance.WaitAtWaypoint(state);
        }
    }

   /* async void WaitAtWaypoint(StateManager state)
    {
        isWaiting = true;
        await Task.Delay(4000);
        currentWaypointIndex = loopWaypoints ? (currentWaypointIndex + 1) % waypoints.Length : 
        Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);
        isWaiting = false;
        state.SwitchState(state.ResetState);

        
    }*/
    
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

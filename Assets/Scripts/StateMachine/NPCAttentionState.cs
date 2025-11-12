using UnityEngine;

public class NPCAttentionState : BaseState
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    private Transform[] waypoints;
    private bool isWaiting;
    private int currentWaypointIndex;
    public override void EnterState(StateManager state)
    {
        Debug.Log("This is the attention state!");
        //waypointParent = waypointParent.Find("WaypointParent");
        //waypoints = new Transform[waypointParent.childCount];
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {
        if (PauseController.IsGamePaused)
            return;
    }

    void MoveToWaypoint()
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

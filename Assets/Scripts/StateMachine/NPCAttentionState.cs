using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NPCAttentionState : BaseState
{
    public GameObject waypointParent;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    public bool loopWaypoints = true;
    private Transform[] waypoints;
    private bool isWaiting;
    private int currentWaypointIndex;
    public override void EnterState(StateManager state)
    {
        Debug.Log("This is the attention state!");
        waypointParent = GameObject.Find("WaypointParent");
        waypoints = new Transform[waypointParent.transform.childCount];

        for (int i = 0; i < waypointParent.transform.childCount; i++)
            waypoints[i] = waypointParent.transform.GetChild(i);
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
        Transform target = waypoints[currentWaypointIndex];
        state.transform.position = Vector2.MoveTowards(state.transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(state.transform.position, target.position) < 0.1f)
        {
           // StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        //currentWaypointIndex = loop
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

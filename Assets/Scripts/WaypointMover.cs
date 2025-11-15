using System;
using System.Collections;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float waitTime = 2f;
    private Transform[] waypoints;
    private bool isWaiting;
    private int currentWaypointIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = new Transform[waypointParent.transform.childCount];

        for (int i = 0; i < waypointParent.childCount; i++)
            waypoints[i] = waypointParent.GetChild(i);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
   /* public Vector3 MoveToWaypoint(StateManager state)
    {
        string currentState = state.GetCurrentState().ToString();
        if (currentState == "AttentionState")
        {

        Transform target = waypoints[currentWaypointIndex];
        Vector3 moveToPosition = transform.position = Vector2.MoveTowards(state.transform.position, target.position, moveSpeed);
        if (Vector2.Distance(state.transform.position, target.position) < 0.1f)
        {
           StartCoroutine(WaitAtWaypoint());
           state.SwitchState(state.ResetState);
           return moveToPosition;
        }
        return moveToPosition;
        }
        
    }
    IEnumerator WaitAtWaypoint()
    {
        while (waitTime > 0f)
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
    }
    */
}

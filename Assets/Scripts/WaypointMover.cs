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
        if (PauseController.IsGamePaused || isWaiting)
            return;

        //MoveToWaypoint();
    }
    
   /* public void MoveToWaypoint(StateManager state)
    {
        if (state.GetCurrentState == "AttentionState")

        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector2.MoveTowards(state.transform.position, target.position, moveSpeed)
    }
    */
}

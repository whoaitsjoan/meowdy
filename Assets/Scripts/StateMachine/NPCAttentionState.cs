using UnityEngine;
using System.Threading.Tasks;

public class NPCAttentionState : BaseState
{
    private GameObject waypointParent;
    private float moveSpeed = 2f;
    private float waitTime = 1000f;
    private bool loopWaypoints = true;
    private Transform[] waypoints;
    private bool isWaiting;
    private int currentWaypointIndex;
    private Timer timer;
    
    
    public override void EnterState(StateManager state)
    {
        Debug.Log("This is the attention state!");
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        Transform t = state.GetComponent<Transform>();
        timer = state.GetComponent<Timer>();
        rb.AddForce(Vector3.zero);
        
        waypointParent = GameObject.Find("WaypointParent");
        waypoints = new Transform[waypointParent.transform.childCount];

        for (int i = 0; i < waypointParent.transform.childCount; i++)
            waypoints[i] = waypointParent.transform.GetChild(i);

        state.transform.GetChild(0).gameObject.SetActive(true);
        
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
           WaitAtWaypoint(state);
        }
    }

    async void WaitAtWaypoint(StateManager state)
    {
        isWaiting = true;
        await Task.Delay(4000);
        isWaiting = false;
        state.SwitchState(state.ResetState);
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

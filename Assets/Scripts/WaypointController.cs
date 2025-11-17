using System.Threading.Tasks;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public static WaypointController instance;
    public Transform waypointParent;
    //this bool controls if we should cycle through the currently used 
    public bool loopWaypoints = true;
    private Transform[] waypoints;
    private int currentWaypointIndex;

    [SerializeField]
    private ScoreTracker scoreTracker;
    [SerializeField]
    private LifeControl livesControl;

     void Awake()
    {
        //Singleton method
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            

        }
        else if (instance != this)
        {
            //instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            

        }
    }

    public Transform GetCurrentWaypoint() { return waypoints[currentWaypointIndex]; }
    void Start()
    {
        
        waypoints = new Transform[waypointParent.transform.childCount];
        //each waypoint is set up in this array to be cycled through in sequence for where NPCs can stop
        for (int i = 0; i < waypointParent.transform.childCount; i++)
            waypoints[i] = waypointParent.transform.GetChild(i);

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
    public async void WaitAtWaypoint(StateManager state)
    {
        
        //this makes the method wait 4 seconds, or 4000 milliseconds to proceed to the next task
        //which lets any animations we want to have play go off
        await Task.Delay(4000);
        
        //this only gets called for the catlover or regular NPC, which will always go back to the reset state, 
        //so we can change that from here
        state.SwitchState(state.ResetState);

        
    }

    public void NextWaypoint()
    {
        currentWaypointIndex = loopWaypoints ? (currentWaypointIndex + 1) % waypoints.Length : 
        Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);
    }

    public void WaypointCollision(StateManager state)
    {
        
        //now this specifically checks what happens depending on the state and/or the name of the object
        //the attention state is only for helpful NPCs so our baseline will be to add to the score
        if (state.GetCurrentState().ToString().Contains("AttentionState"))
        {
            Debug.Log("Cash update!");
            scoreTracker.AddCash(state);
            //then, if this NPC happens to be a fishmonger, we can also add 1 fish to the count
            if(state.gameObject.name.Contains("Fishmonger"))
                scoreTracker.AddFish();
        }
        //otherwise, if the NPC is not someone we want, someone in the angry state, then we need to subtract a life
        else if (state.GetCurrentState().ToString().Contains("AngryState"))
        {
            livesControl.LoseLife();
            //since the angry NPCs aren't waiting to get robbed, their state can be switched from here right away
            state.SwitchState(state.ResetState);
        }

    }
}

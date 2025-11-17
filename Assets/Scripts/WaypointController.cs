using System.Threading.Tasks;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public static WaypointController instance;
    public Transform waypointParent;
    public bool loopWaypoints = true;
    private Transform[] waypoints;
    private int currentWaypointIndex;

  

     void Awake()
    {
        //Singleton method
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            //instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }

    public Transform GetCurrentWaypoint() { return waypoints[currentWaypointIndex]; }
    void Start()
    {
        waypoints = new Transform[waypointParent.transform.childCount];

        for (int i = 0; i < waypointParent.transform.childCount; i++)
            waypoints[i] = waypointParent.transform.GetChild(i);

    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
    public async void WaitAtWaypoint(StateManager state)
    {
        await Task.Delay(4000);
        currentWaypointIndex = loopWaypoints ? (currentWaypointIndex + 1) % waypoints.Length : 
        Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);
        state.SwitchState(state.ResetState);

        
    }
}

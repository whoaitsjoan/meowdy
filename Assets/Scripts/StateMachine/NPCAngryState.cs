using UnityEngine;

public class NPCAngryState : BaseState
{
    private float moveSpeed = 3f;
    private Rigidbody2D rb;
    
    public override void EnterState(StateManager state)
    {
       state.IsTransitioningState = false;
       rb = state.GetComponent<Rigidbody2D>();
       rb.linearVelocity = Vector3.zero;
       if (state.gameObject.name.Contains("Dobby") || state.gameObject.name.Contains("Piggie"))
       {
        Animator mainAnimator = state.GetComponent<Animator>();
        mainAnimator.SetFloat("moveSpeed", 2f);
        state.transform.GetChild(0).gameObject.SetActive(true);
       }
       else
        {
        state.transform.GetChild(4).gameObject.SetActive(true);
        Animator torsoAnim = state.transform.GetChild(0).GetComponent<Animator>();
        torsoAnim.SetFloat("moveSpeed", 2f);

        Animator headHandsAnim = state.transform.GetChild(1).GetComponent<Animator>();
        headHandsAnim.SetFloat("moveSpeed", 2f);

        Animator legsAnim = state.transform.GetChild(2).GetComponent<Animator>();
        legsAnim.SetFloat("moveSpeed", 2f);

        Animator feetAnim = state.transform.GetChild(3).GetComponent<Animator>();
        feetAnim.SetFloat("moveSpeed", 2f);
        }
        
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {
        if (PauseController.IsGamePaused)
            return;

        MoveToWaypoint(state);

    }
    void MoveToWaypoint(StateManager state)
    {
       
        Transform target = WaypointController.instance.GetCurrentWaypoint();
        state.transform.position = Vector2.MoveTowards(state.transform.position, target.position, moveSpeed * Time.deltaTime);
        WaypointController.instance.NextWaypoint(state);

        if (Vector2.Distance(state.transform.position, target.position) < 0.1f)
        {
           Transform t = state.GetComponent<Transform>();
            if (t.position.x < 0 && t.position.y > 0)
        {
            rb.AddForce(new Vector3(40, 40, 0));
        }
         else if (t.position.x > 10)
        {
           state.transform.localScale = new Vector3(state.transform.localScale.x *-1, state.transform.localScale.y, state.transform.localScale.z); 
           rb.AddForce(new Vector3(-40, 40, 0));
        }
           WaypointController.instance.WaypointCollision(state);
        }
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

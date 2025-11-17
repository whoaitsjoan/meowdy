using UnityEngine;

public class NPCResetState : BaseState
{
    
    public override void EnterState(StateManager state)
    {
        Debug.Log("Reset State!");
        Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
        Transform t = state.GetComponent<Transform>();
        if (t.position.x < 0 && t.position.y > 0)
        {
            rb.AddForce(new Vector3(20, 20, 0));
        }
         else if (t.position.x > 10)
        {
           state.transform.localScale = new Vector3(state.transform.localScale.x *-1, state.transform.localScale.y, state.transform.localScale.z); 
           rb.AddForce(new Vector3(-20, 20, 0));
        }
        state.transform.GetChild(0).gameObject.SetActive(false);
    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override void UpdateState(StateManager state)
    {
            //changed polygon collider to capsule
            if (!state.GetComponent<CapsuleCollider2D>().IsTouchingLayers(LayerMask.NameToLayer("People")))
            state.SwitchState(state.WalkingState);

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

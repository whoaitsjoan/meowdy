using System.Threading.Tasks;
using UnityEngine;

public class NPCQuestioningState : BaseState
{
    public override void EnterState(StateManager state)
    {
       state.IsTransitioningState = false;
       Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
       rb.AddForce(Vector3.zero);
       //this grabs the question mask icon and leaves that for while the state is active
       state.transform.GetChild(0).gameObject.SetActive(true);

    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override async void UpdateState(StateManager state)
    {
        await Task.Delay(4000);
        state.SwitchState(state.WalkingState);
    }
    
    public override void OnTriggerEnter2D(StateManager state, Collider2D other)
    {
         if (other.CompareTag("Meow") && !state.IsTransitioningState) 
        {
            Debug.Log("Collision!");
            state.IsTransitioningState = true;
            state.SwitchState(state.AttentionState);
        }
    }

    public override void OnTriggerStay2D(StateManager state, Collider2D other)
    {
        
    }

    public override void OnTriggerExit2D(StateManager state, Collider2D other)
    {
        
    }

}

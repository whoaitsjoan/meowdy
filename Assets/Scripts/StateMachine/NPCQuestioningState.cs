using System.Threading.Tasks;
using UnityEngine;

public class NPCQuestioningState : BaseState
{
    public override void EnterState(StateManager state)
    {
       state.IsTransitioningState = false;
       Rigidbody2D rb = state.GetComponent<Rigidbody2D>();
       rb.linearVelocity = Vector3.zero;
       //this grabs the question mask icon and leaves that for while the state is active
       if (state.gameObject.name.Contains("Fishmonger"))
       state.transform.GetChild(4).gameObject.SetActive(true);
       else
       state.transform.GetChild(5).gameObject.SetActive(true);

    }

    public override void ExitState(StateManager state)
    {
       
    }
    public override async void UpdateState(StateManager state)
    {
        if (PauseController.IsGamePaused)
            return;
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

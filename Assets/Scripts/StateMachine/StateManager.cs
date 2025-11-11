using UnityEngine;

public class StateManager : MonoBehaviour
{

BaseState CurrentState;
   public NPCWalkingState WalkingState = new NPCWalkingState();
   public NPCAttentionState AttentionState = new NPCAttentionState();
   public NPCQuestioningState QuestioningState = new NPCQuestioningState();
   public NPCAngryState AngryState = new NPCAngryState();
   public NPCResetState ResetState = new NPCResetState();
    protected bool IsTransitioningState = false;
    
    void Start() 
    {
        CurrentState = WalkingState;
        CurrentState.EnterState(this); 
        }


    void Update()
    {
        

        
    }
    public void SwitchState(BaseState state)
    {
        CurrentState = state;
        CurrentState.EnterState(this);
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        CurrentState.OnTriggerEnter2D(this, other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        CurrentState.OnTriggerStay2D(this, other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CurrentState.OnTriggerExit2D(this, other);
    }



}

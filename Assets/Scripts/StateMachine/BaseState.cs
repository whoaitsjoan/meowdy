using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(StateManager state);
    public abstract void ExitState(StateManager state);
    public abstract void UpdateState(StateManager state);
    public abstract void OnTriggerEnter2D(StateManager state, Collider2D other);
    public abstract void OnTriggerStay2D(StateManager state, Collider2D other);
    public abstract void OnTriggerExit2D(StateManager state, Collider2D other);
}

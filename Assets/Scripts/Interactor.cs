using UnityEngine;

//this interface defines an interact method for any object that can be interacted with
//to pull from easily and share methods across objects with similar use-cases
interface IInteractable {
    public void Hit();
    public void Graze();
}

public class Interactor : StateManager<Interactor.InteractorStates>
{
    public enum InteractorStates
    {
        Walking,
        Attention,
        Questioning,
        Angry,
        Reset,
    }
    public GameObject InteractorSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

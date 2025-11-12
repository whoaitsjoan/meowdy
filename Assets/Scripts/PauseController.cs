using UnityEngine;

public class PauseController : MonoBehaviour
{
    InputSystem_Actions input;
    public static bool IsGamePaused { get; private set; }

    public static void SetPause (bool pause)
    {
        IsGamePaused = pause;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    InputSystem_Actions input;

    public UnityEvent gameOver, resetGame;
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
        input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        input.Player.Disable();
        input.UI.Enable();
        gameOver.Invoke();
    }
    
    public void ResetGame()
    {
        input.UI.Disable();
        input.Player.Enable();
        resetGame.Invoke();
    }
}

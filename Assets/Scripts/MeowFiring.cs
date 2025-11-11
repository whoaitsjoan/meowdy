using UnityEngine;
using UnityEngine.InputSystem;

public class MeowFiring : MonoBehaviour
{
    InputSystem_Actions input;
    public GameObject meow;
    public Transform meowTransform;
    public bool canMeow;
    private float timer;
    public float timeBetweenMeowing;
    
    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Player.Meow.performed += OnMeow;
    }
    void Start()
    {

    }
    private void OnEnable()
    {
        input.Player.Meow.performed += OnMeow;
        input.Enable();
    }

    private void OnDisable()
    {
        input.Player.Meow.performed -= OnMeow;
        input.Disable();
    }

    void OnMeow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMeow)
        {
            //Every few seconds or so depending on the timer, hitting the meow button will spawn a projectile
            //and the meowPosition handles where/how that projectile moves
            canMeow = false;
            Debug.Log("The current position of the pointer is" + meowTransform.position);
            Instantiate(Resources.Load("MeowProjectile", typeof(GameObject)) as GameObject, meowTransform.position,
            Quaternion.Euler(meowTransform.rotation.x, meowTransform.rotation.y, 0));
        }
    }

    void Update()
    {
        HandleMeowing();
    }
      private void HandleMeowing()
    {
        if (!canMeow)
        {
            //tracking time between meows in realtime here
            timer += Time.deltaTime;
            if (timer > timeBetweenMeowing)
            {
                canMeow = true;
                timer = 0;
            }
        }
    }
    

}

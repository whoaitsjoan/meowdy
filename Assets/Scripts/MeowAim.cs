using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeowAim : MonoBehaviour
{
public event EventHandler<MeowFireEventArgs> MeowFire;
    public class MeowFireEventArgs : EventArgs
    {
        public Vector3 pointerEndPosition;
        public Vector3 meowDirection;
    }

    private Camera mainCamera;
    public GameObject cat;
    public float distance;
    private float angle;

    InputSystem_Actions input;
    public Vector2 mousePosition;

    public GameObject meow;

    public Transform meowTransform;

    public Transform meowFireEndPointTransform;
    public bool canMeow;
    private float timer;
    public float timeBetweenMeowing;
    

    private void Awake()
    {
        //input here is bringing in a new instance of our default input map into the scene 
        input = new InputSystem_Actions();
        //and now input is calling OnLook or OnMeow anytime those inputs are performed based on the input map
        input.Player.Look.performed += OnLook;
        input.Player.Meow.performed += OnMeow;
    }
    private void OnEnable()
    {
        //when this script is turned on, it will also do a separate check on OnLook and make sure input is enable
        input.Player.Look.performed += OnLook;
        input.Player.Meow.performed += OnMeow;
        input.Enable();
    }

    private void OnDisable()
    {
        //this does the reverse and makes sure input is disabled when this script turns off
        input.Player.Look.performed -= OnLook;
        input.Player.Meow.performed -= OnMeow;
        input.Disable();
    }

    void OnLook(InputAction.CallbackContext ctx)
    {
        //whenever Look is performed from our InputMap, mousePosition will always read the value of that input 
        //from any compatible device
        if (ctx.performed)
        { mousePosition = ctx.ReadValue<Vector2>(); }
    }
    
    void Start()
    {
      mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    void Update()
    {
        HandleAiming();
        HandleMeowing();
        
    }
    private void HandleAiming()
    {
        
        //a new vector3 is made here to track the mouse's position
        Vector3 v3 = mousePosition;

        //because the look function only gives a vector2, we get the z value by subtracting the camera's z value
        //from the cat's z position
        v3.z = cat.transform.position.z - mainCamera.transform.position.z;
        //then this full vector3 gets converted into coordinate space like what we see in the editor
        v3 = mainCamera.ScreenToWorldPoint(v3);
        //and that vector gets offset by the cat's position
        v3 = (v3 - cat.transform.position).normalized;

        //the angle part here is less important with the pointer being a circle but will point in the right direction
        //if we have an arrow or any other polygonal object in its place
        angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
        //if (angle < 0.0f) angle += 360.0f;
        transform.localEulerAngles = new Vector3(0, 0, angle);

        //the x and y position of the pointer are essentially being calculated manually here
        //with a cosine and sine function converting our angle to degrees and multiplying it by our distance variable
        //distance gets set in the editor for exactly how far away we want the pointer to be
        float xPos = Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
        float yPos = Mathf.Sin(Mathf.Deg2Rad * angle) * distance;

        //finally, the local position of the pointer becomes this new vector3, adding the transform of the cat
        //to our x and y position respectively, and multiplying that by 4 to get some even spacing
        transform.localPosition = new Vector3(cat.transform.position.x + xPos * 4, cat.transform.position.y + yPos * 4, 0);


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

    void OnMeow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMeow)
        {
            canMeow = false;
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //Every few seconds or so depending on the timer, hitting the meow button will spawn a projectile
            //and the meowPosition handles where/how that projectile moves
            MeowFire?.Invoke(this, new MeowFireEventArgs
            {
                pointerEndPosition = meowFireEndPointTransform.position,
                meowDirection = mousePosition,
            });
            
        }
    } 

    
}

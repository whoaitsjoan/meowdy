using System.Collections.Generic;
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

    public ObjectPooler meowPool;
    public ObjectPooler reverseMeowPool;

    public Vector2 mousePosition;

    private Camera mainCamera;

    public Animator meowAnimator;

    public AudioSource meowSource;
    public List<AudioClip> meowList = new List<AudioClip>();
    public AudioClip currentMeow;
    
    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        input = new InputSystem_Actions();
        input.Player.Meow.performed += OnMeow;
        input.Player.Look.performed += OnLook;
        
    }
    void Start()
    {

    }
    private void OnEnable()
    {
        input.Player.Meow.performed += OnMeow;
        input.Player.Look.performed += OnLook;
        input.Enable();
    }

    private void OnDisable()
    {
        input.Player.Meow.performed -= OnMeow;
        input.Player.Look.performed += OnLook;
        input.Disable();
    }

    void OnLook(InputAction.CallbackContext ctx)
    {
        //whenever Look is performed from our InputMap, mousePosition will always read the value of that input 
        //from any compatible device
        if (ctx.performed)
        { mousePosition = ctx.ReadValue<Vector2>(); }
    }

    void OnMeow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMeow)
        {
            //Every few seconds or so depending on the timer, hitting the meow button will spawn a projectile
            //and the meowPosition handles where/how that projectile moves
            canMeow = false;
            Debug.Log("The current position of the pointer is" + meowTransform.position);
            meowAnimator.SetTrigger("Meow");
            int rand = Random.Range(0,meowList.Count);
            currentMeow = meowList[rand];
            meowSource.clip = currentMeow;
            meowSource.Play();
            
           /* mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = mainCamera.nearClipPlane;
            Vector3 rotation = transform.position - mousePosition;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            Debug.Log(rot);
            */
            if (mousePosition.x < 700)
            {
                Debug.Log("I fired in reverse");
                meow = reverseMeowPool.GetPooledObject();
            }
            else
            {
                Debug.Log("I fired!");
                meow = meowPool.GetPooledObject();
            }
            meow.transform.position = meowTransform.position;
            meow.transform.Rotate(meowTransform.rotation.x, meowTransform.rotation.y, 0);
            meow.SetActive(true);
            //Instantiate(Resources.Load("MeowProjectile", typeof(GameObject)) as GameObject, meowTransform.position,
            // Quaternion.Euler(meowTransform.rotation.x, meowTransform.rotation.y, 0));
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
                meowAnimator.ResetTrigger("Meow");
            }
        }
    }
    

}

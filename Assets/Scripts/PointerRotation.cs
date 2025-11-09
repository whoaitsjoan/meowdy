using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerRotation : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject cat;
    public float distance;
    private float angle;

    InputSystem_Actions input;
    public Vector2 mousePosition;

    public GameObject meow;
    public Transform meowTransform;
    public bool canMeow;
    private float timer;
    public float timeBetweenMeowing;
    

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Player.Look.performed += OnLook;
        input.Player.Meow.performed += OnMeow;
    }
    private void OnEnable()
    {
        input.Player.Look.performed += OnLook;
        input.Enable();
    }

    private void OnDisable()
    {
        input.Player.Look.performed -= OnLook;
        input.Disable();
    }

    void OnLook(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        { mousePosition = ctx.ReadValue<Vector2>(); }

    }
    
    void OnMeow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canMeow)
        {
            canMeow = false;
            Instantiate(meow, meowTransform.position, Quaternion.identity);
        }
    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = mousePosition;
        v3.z = (cat.transform.position.z - mainCamera.transform.position.z);
        v3 = mainCamera.ScreenToWorldPoint(v3);
        v3 = v3 - cat.transform.position;
        angle = Mathf.Atan2(v3.y, v3.x) * Mathf.Rad2Deg;
        if (angle < 0.0f) angle += 360.0f;
        transform.localEulerAngles = new Vector3(0, 0, angle);
        float xPos = Mathf.Cos(Mathf.Deg2Rad * angle) * distance;
        float yPos = Mathf.Sin(Mathf.Deg2Rad * angle) * distance;
        transform.localPosition = new Vector3(cat.transform.position.x + xPos * 4, cat.transform.position.y + yPos * 4, 0);
        
        if (!canMeow)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenMeowing)
            {
                canMeow = true;
                timer = 0;
            }
        }
        //Vector3 worldPosition = mainCamera.WorldToScreenPoint(new Vector3(mousePosition.x, mousePosition.y, mainCamera.nearClipPlane));
        /*Vector3 catVector = Camera.main.WorldToScreenPoint(cat.position);
        Vector3 mouse3 = mousePosition;
        catVector = mouse3 - catVector;
        float angle = Mathf.Atan2(catVector.y, catVector.x) * Mathf.Rad2Deg;
        pivot.position = cat.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
       // catSprite.transform.eulerAngles = new Vector3(pivot.rotation.x, pivot.rotation.y, 0);
*/
    }
}

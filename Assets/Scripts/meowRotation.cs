using UnityEngine;
using UnityEngine.InputSystem;

public class meowRotation : MonoBehaviour
{
    [SerializeField] private Camera newCamera;
    public Vector2 mousePosition;
    InputSystem_Actions input;

    private void Awake()
    {
        input = new InputSystem_Actions();
        input.Player.Look.performed += OnLook;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = newCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, newCamera.nearClipPlane));
        Vector3 rotateDirection = (worldPosition - transform.position).normalized;
        rotateDirection.z = 0; 
        float angle = Mathf.Atan2(rotateDirection.y,rotateDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }
}

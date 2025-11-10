using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class TestRotation : MonoBehaviour
{
    public event EventHandler<MeowFireEventArgs> MeowFire;
    public class MeowFireEventArgs : EventArgs
    {
        public Vector3 pointerEndPosition;
        public Vector3 meowDirection;
    }

    InputSystem_Actions input;
    private Transform meowTransform;
    private Transform meowFireEndPointTransform;
    private Camera mainCamera;

    private void Awake()
    {
        meowTransform = transform.Find("meowPointer");
        meowFireEndPointTransform = transform.Find("PointerEnd");
        input = new InputSystem_Actions();
        input.Player.Meow.performed += OnMeow;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleAiming();
       

    }

    private void HandleAiming()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        meowTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);

        Vector3 aimLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.y = -1f;
        }
        else
        {
            aimLocalScale.y = +1f;
        }
        meowTransform.localScale = aimLocalScale;
    }

    void OnMeow(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            
            MeowFire?.Invoke(this, new MeowFireEventArgs
            {
                pointerEndPosition = meowFireEndPointTransform.position,
                meowDirection = mousePosition,
            });
            
        }
    } 
}

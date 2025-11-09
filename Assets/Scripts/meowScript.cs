using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEditor.Callbacks;

public class MeowScript : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody2D rb;
    public float force;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();
            mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = mainCamera.nearClipPlane;
            Vector3 direction = mousePosition - transform.position;
            Vector3 rotation = transform.position - mousePosition;
            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

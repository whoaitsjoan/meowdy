using UnityEngine;
using UnityEngine.InputSystem;


public class MeowPosition : MonoBehaviour
{
    private Vector3 mousePosition;
    private Camera mainCamera;
    private Rigidbody2D rb;
    public float force;

        
        void Start()
        {
            //this starts by pulling the scene camera
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rb = GetComponent<Rigidbody2D>();

            //the mouse position is a vector2, 
            // with the z based on the nearclip plane of our camera
            mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = mainCamera.nearClipPlane;

            //now our projectile's direction and rotation can work based on mouse position and our object's transform
            Vector3 direction = (mousePosition - transform.position).normalized;
            Vector3 rotation = transform.position - mousePosition;

            //finally the actual speed of the projectile gets based on our direction, 
            // modified by our preferred force value

            rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
            
            //this additional rotation value will likely change again but this is where rotation gets similarly used
            //and then updates our projectile's transform
            float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 180);
        }

       
        void Update()
        {

        }
    }

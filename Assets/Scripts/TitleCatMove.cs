using UnityEditor.UI;
using UnityEngine;

public class TitleCatMove : MonoBehaviour
   
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject cat;
    public BoxCollider2D back;
    //public GameObject stop;
    //public BoxCollider2D stopZone;
    private Vector3 og;
    public TitleCatSpawn TitleCatSpawn;
    public float speed;
    void Start()
    {
        back = GetComponent<BoxCollider2D>();
        //stopZone = stop.GetComponent<BoxCollider2D>();
        og = cat.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)     
        {
            cat.transform.position += new Vector3(speed, 0f);
            if(cat.transform.position.x > 2050)
            {
                cat.transform.position = og;
                cat.SetActive(false);
                
                TitleCatSpawn.numberSpawned--;
            }
        }
        
    }

   
}

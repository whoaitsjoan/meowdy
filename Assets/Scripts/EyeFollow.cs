using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{   
    public GameObject pointer;

    void Start()
    {
        
    }


    void Update()
    {
        eyeFollow();
    }

    void eyeFollow(){
        Vector3 pointerpos = pointer.transform.position;

        Vector2 direction = new Vector2(
            (pointerpos.x - transform.position.x),
            (pointerpos.y - transform.position.y)     
        );
        transform.up = direction;
    }
}
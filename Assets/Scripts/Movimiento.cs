using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float x;
    private float z;

    

    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(x, 0, z) * 5;

        
    }
}

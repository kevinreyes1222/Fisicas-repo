using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float x;
    private float z;
    public Transform cameraTransform;

    

    void FixedUpdate()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody>().velocity = (cameraTransform.forward* z + cameraTransform.right * x) * Time.deltaTime * 100 ;

       
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public Vector3 gravityValue; // Define el valor de gravedad que deseas para la escena
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = gravityValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

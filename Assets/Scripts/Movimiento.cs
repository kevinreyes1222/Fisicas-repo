using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    float jump;
    public Transform cameraTransform;
    Rigidbody rb;
    public float fuerzaSalto;
    public bool canJump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        jump = Input.GetAxis("Jump");
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        print(jump);
        Vector3 salto = new Vector3(0, fuerzaSalto, 0);
        if (canJump && jump != 0)
        {
            rb.AddForce(salto, ForceMode.Impulse);

        }
    }

    void FixedUpdate()
    {


        var m = (cameraTransform.forward * vertical + cameraTransform.right * horizontal) * Time.deltaTime * 100;
        //rb.velocity = ;
        rb.velocity = new Vector3(m.x, rb.velocity.y, m.z);


    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }
}

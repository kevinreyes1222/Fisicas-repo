using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AgarraSueltaLanza : MonoBehaviour
{
    public GameObject cubo;
    public Transform mano;
    public float fuerza;

    private bool activo;
    private bool enMano;
    private Vector3 escala;

    public float tiempo = 0f;

    private void Start()
    {
        //Se registra la escala original del objeto para que no permanezca cambiada al ser recogida
        escala = cubo.transform.localScale;
    }

    void Update()
    {
        if(activo == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //Se transforma en hijo de mano y se mueve a su posición
                cubo.transform.SetParent(mano);
                cubo.transform.position = mano.position;
                cubo.transform.rotation = mano.rotation;
                cubo.GetComponent<Rigidbody>().isKinematic = true;
                enMano = true;
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            //El objeto sale del padre y se le aplica una fuerza y su escala original
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            cubo.transform.localScale = escala;

            if(enMano == true)
            {
                cubo.GetComponent<Rigidbody>().AddForce(transform.forward * fuerza, ForceMode.Impulse);
                enMano = false;
                print(tiempo = Time.time);
                
                
            }
        }

        

        if(Input.GetKeyDown(KeyCode.G))
        {
            //El objeto sale del padre y se le aplica su escala original
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            cubo.transform.localScale = escala;
        }
    }


    
    private void OnTriggerEnter(Collider other)
    {
        //Trigger de entrada
        if(other.tag == "Player")
        {
            activo = true;
        }

        print(Time.time - tiempo);

    }

    private void OnTriggerExit(Collider other)
    {
        //Trigger de salida
        if (other.tag == "Player")
        {
            activo = false;
        }
    }
}

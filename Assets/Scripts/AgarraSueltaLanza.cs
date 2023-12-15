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
    public  static bool lanzado = false;
    public static bool soltado = false;
    private bool activo;
    public static bool enMano;
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
                lanzado = true;
                print(tiempo = Time.time);
                
                
            }
        }

        

        if(Input.GetKeyDown(KeyCode.G))
        {
            //El objeto sale del padre y se le aplica su escala original
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            cubo.transform.localScale = escala;
            soltado = true;
        }
    }


    
    private void OnTriggerEnter(Collider other)
    {
        //Trigger de entrada
        if(other.tag == "Player")
        {
            activo = true;
            lanzado = false;
            soltado = false;
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

        if (this.tag == "Cubo")
        {
            cubo.transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }    
    
}

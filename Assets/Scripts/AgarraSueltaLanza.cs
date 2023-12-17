using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AgarraSueltaLanza : MonoBehaviour
{

    public GameObject cubo;
    public Transform mano;
    public float fuerza;
    public bool lanzado = false;
    public bool soltado = false;
    private bool activo;
    public bool enMano;
    private Vector3 escala;

    public static bool PrimerLanzado = false;
    public static bool PrimerSoltado = false;
    public static bool PrimerEnMano = false;

    //public float tiempo = 0f;
    private bool haTocadoElSuelo = false;
    private float tiempoDeVuelo = 0f;

    public Canvas canvasTiempo;
    public GameObject TextObjetTime;
    Text texto;

    private void Start()
    {
        //Se registra la escala original del objeto para que no permanezca cambiada al ser recogida
        escala = cubo.transform.localScale;
        texto = TextObjetTime.GetComponent<Text>();
    }

    void Update()
    {
        if (haTocadoElSuelo) {
            tiempoDeVuelo += Time.deltaTime;
        }
        if (activo == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Se transforma en hijo de mano y se mueve a su posición
                cubo.transform.SetParent(mano);
                cubo.transform.position = mano.position;
                cubo.transform.rotation = mano.rotation;
                cubo.GetComponent<Rigidbody>().isKinematic = true;
                enMano = true;
                PrimerEnMano = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            //El objeto sale del padre y se le aplica una fuerza y su escala original
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            cubo.transform.localScale = escala;

            if (enMano == true)
            {

                cubo.GetComponent<Rigidbody>().AddForce(transform.forward * fuerza, ForceMode.Impulse);
                enMano = false;
                lanzado = true;
                PrimerLanzado = true;

                if (cubo.tag == "Cubo")
                {
                    cubo.transform.localScale = escala*2;
                }

            }
        }



        if (Input.GetKeyDown(KeyCode.G))
        {
            //El objeto sale del padre y se le aplica su escala original
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            cubo.transform.localScale = escala;
            soltado = true;
            PrimerSoltado = true;
        }
    }

    public void MostrarTiempo(){
        canvasTiempo.gameObject.SetActive(true);
        //float tiempoPasado = tiempo = Time.time;
        texto.text = "Recuerda que en cada planeta los objetos caen en tiempos diferentes debido a su gravedad Este lanzamiento duro " + tiempoDeVuelo.ToString() +" segundos";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        haTocadoElSuelo = true;

    }

    public void Desactivar()
    {
        canvasTiempo.gameObject.SetActive(false);
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

        if (other.tag == "Piso")
        {
                MostrarTiempo();

        }
        //print(Time.time - tiempo);

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

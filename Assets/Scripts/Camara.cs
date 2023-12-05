using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform personaje;


    // Ajusta la posici�n relativa de la c�mara respecto al personaje.
    public Vector3 offset = new Vector3(10, 15, 10);

    public Vector2 sensibilidad;
    private float camaraX;
    private float camaraY;

    void Start()
    {
        //impide que el cursor se vea y se salga de la ventana de juego 
        Cursor.lockState = CursorLockMode.Locked;

       

    }
    void Update()
    {
        if (personaje != null)
        {
            // Actualiza la posici�n de la c�mara para seguir al personaje con un peque�o desfase.
            transform.position = personaje.position + offset  ;

            camaraX = Input.GetAxisRaw("Mouse X");
            camaraY = Input.GetAxisRaw("Mouse Y");

            if (camaraX != 0)
            {
             transform.Rotate(Vector3.up * camaraX * sensibilidad.x, Space.World);
            }

            if (camaraY != 0)
            {
                transform.Rotate(Vector3.left * camaraY * sensibilidad.y);
            }
        }
    }

}

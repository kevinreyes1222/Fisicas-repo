using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform personaje; // Asigna el objeto del personaje en el Inspector de Unity.

    public Vector3 offset = new Vector3(10, 15, 10); // Ajusta la posici�n relativa de la c�mara respecto al personaje.

    void Update()
    {
        if (personaje != null)
        {
            // Actualiza la posici�n de la c�mara para seguir al personaje con un peque�o desfase.
            transform.position = personaje.position + offset;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform personaje; // Asigna el objeto del personaje en el Inspector de Unity.

    public Vector3 offset = new Vector3(10, 15, 10); // Ajusta la posición relativa de la cámara respecto al personaje.

    void Update()
    {
        if (personaje != null)
        {
            // Actualiza la posición de la cámara para seguir al personaje con un pequeño desfase.
            transform.position = personaje.position + offset;
        }
    }

}

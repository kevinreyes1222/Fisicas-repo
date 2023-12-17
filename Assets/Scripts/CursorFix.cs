using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFix : MonoBehaviour
{
   public  CamaraSet camaraSet;
    // Start is called before the first frame update
    void Start()
    {
        camaraSet.MostrarCursor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

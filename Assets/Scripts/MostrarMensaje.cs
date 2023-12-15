using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarMensaje : MonoBehaviour
{
    static bool completado = false;
    float vertical;
    public GameObject textObject;
  
    Text texto;
    public string[] textos;
    public AgarraSueltaLanza agarrarCode;

    int secuencia = 0;
    // Start is called before the first frame update
    void Start()
    {
       texto  = textObject.GetComponent<Text>();
        texto.text = textos[0];
        if (completado == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        switch (secuencia)
        {
            case 0:
                if (vertical > 0)
                {
                    texto.text = textos[1];
                    secuencia++;
                }
                break;
                case 1:
                if (AgarraSueltaLanza.enMano)
                {
                    texto.text = textos[2];
                    secuencia++;
                    print(AgarraSueltaLanza.enMano);
                }
                break;
                case 2:
                if (AgarraSueltaLanza.lanzado)
                {
                    texto.text = textos[3];
                    secuencia++;

                }
                break;
                case 3:
                if (AgarraSueltaLanza.enMano)
                {
                    texto.text = textos[4];
                    secuencia++;
                }
                
                break;
                case 4:
                if (AgarraSueltaLanza.soltado)
                {
                    texto.text = textos[5];
                   completado = true;
                }

                break;
                
        }
        
        

    }
}

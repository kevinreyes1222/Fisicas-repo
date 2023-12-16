using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioLunar : MonoBehaviour
{
    public SceneReference mars;
    public SceneReference earth;
    public Canvas canvaSelector;
    public Canvas canvaMessage;
    public CamaraSet camara;
    // Start is called before the first frame update
    public void irArMarte()
    {
        SceneManager.LoadScene(mars);
    }

    public void irAlaTierra() {
        SceneManager.LoadScene(earth);

    }

    private void OnTriggerEnter(Collider other)
    {
        canvaSelector.gameObject.SetActive(true);
        camara.GetComponent<CamaraSet>().enabled = false;

    }

    public void Desactivar()
    {
        canvaSelector.gameObject.SetActive(false);
        camara.GetComponent<CamaraSet>().enabled = true;

    }
    public void Desactivar2()
    {
        canvaMessage.gameObject.SetActive(false);
    }
}

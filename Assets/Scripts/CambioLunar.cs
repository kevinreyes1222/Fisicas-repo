using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioLunar : MonoBehaviour
{
    public SceneReference mars;
    public SceneReference earth;
    public Canvas canva;

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
        canva.gameObject.SetActive(true);
    }

    public void Desactivar()
    {
        canva.gameObject.SetActive(false);
    }
}

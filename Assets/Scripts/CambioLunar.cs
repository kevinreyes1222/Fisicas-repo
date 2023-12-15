using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioLunar : MonoBehaviour
{
    public SceneReference mars;
    public SceneReference earth;

    // Start is called before the first frame update
   public void irArMarte()
    {
        SceneManager.LoadScene(mars);
    }

    public void irAlaTierra() {
        SceneManager.LoadScene(earth);

    }
}

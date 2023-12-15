using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public SceneReference sceneSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiar()
    {
        SceneManager.LoadScene(sceneSelected);

    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneSelected);  
    }
}

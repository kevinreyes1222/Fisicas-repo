using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionMano : MonoBehaviour
{
     Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Movimiento", 1f);
        }

        else
        { anim.SetFloat("Movimiento", 0f); }
    }
}

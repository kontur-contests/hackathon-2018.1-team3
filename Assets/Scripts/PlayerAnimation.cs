using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            anim.Play("SimpleUp");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.Play("SimpleRight");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.Play("SimpleDown");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.Play("SimpleLeft");
        }

    }

}

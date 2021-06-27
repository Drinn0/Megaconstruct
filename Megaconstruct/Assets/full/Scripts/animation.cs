using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public Animator animwalk;
    public MoveScript script;

    // Start is called before the first frame update
    void Start()
    {
        
        //animwalk = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetAxis("Horizontal") != 0 && script._isGrounded)
        {
            animwalk.SetBool("isRunning", true);
        }
        else
            animwalk.SetBool("isRunning", false);


    }
}

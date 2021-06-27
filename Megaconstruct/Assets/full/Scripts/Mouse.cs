using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

   

    float actualDistance;
    private void Start()
    {

  
    }





    private void Update()
    {



        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 71f; // Set this to be the distance you want the object to be placed in front of the camera.
        this.transform.position = Camera.main.ScreenToWorldPoint(mousepos);
    }




}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{		
	public Transform targetobject;


	public Vector3 cameraoffset;

	public float smoothfactor = 5.5f;
    // Start is called before the first frame update
    void Start()
    {
        cameraoffset = transform.position - targetobject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newposition = targetobject.transform.position + cameraoffset;
        transform.position = Vector3.Slerp(transform.position, newposition, smoothfactor);
    	

    }
}

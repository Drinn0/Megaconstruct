using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    public GameObject _Holder;
    public LineRenderer _linerenderer;
    public SpringJoint _spring;

    public GameObject _Mouse;
    private bool _check;
    private RaycastHit hit;
    public float _HookLength;
    private Ray _mouseray;


     // Start is called before the first frame update
     void Start()
    {
        _check = true;

        _linerenderer = GetComponent<LineRenderer>();
        _spring = GetComponent<SpringJoint>();
        _mouseray = new Ray(_Holder.transform.position, _Mouse.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        Vector3[] _positions = new Vector3[]
        {
            _Holder.transform.position,
            _spring.connectedAnchor
        };


       
        
       if ( Physics.Raycast(_mouseray, out hit, _HookLength))
        {
            // ancoora segue o Hook
            if (Input.GetMouseButtonDown(0))
            {
                _spring.connectedAnchor = _Mouse.transform.position;


                _check = false;
            }

        }
        Debug.DrawRay(_Holder.transform.position , _Mouse.transform.position );
        Debug.DrawLine(_Mouse.transform.position, _Mouse.transform.position * 5);

        if (_check == true) // ancora segue o player
        {
            _spring.connectedAnchor = _Holder.transform.position;
            _linerenderer.enabled = false;
        }
        else
        {
            _linerenderer.enabled = true;
            _linerenderer.SetPositions(_positions);
        }
        if (Input.GetKey(KeyCode.R)&& _check == false) 
        {
            _check = true;
        }
    
    
    
    
    
    
    }










}

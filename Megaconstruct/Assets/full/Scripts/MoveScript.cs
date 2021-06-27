using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    public Vector2 movement;
    private Rigidbody _rigidbody;
    public float _movementforce = 2;
    public bool _facingRight = true;
    public float _extragravity;

    public Text debug;
    
    private bool _ismoving = false;
    public float _jumpforce = 500;
    public bool _isGrounded = true;
    private float _distToGround = 0.8f;

    void Awake()
    {

        
        
        _rigidbody = GetComponent<Rigidbody>();
       
    
    }

    private void Update()
    {

        // verifica se ta no chão
        if (_isGrounded)
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);

       
        
        // muda direção do modelo
        if ((Input.GetAxis("Horizontal") > 0 && !_facingRight) || (Input.GetAxis("Horizontal") < 0 && _facingRight))
            if (_isGrounded)
                flip();
        // correção do flip parado
        if (Input.GetAxis("Horizontal") == 0)
            if (_isGrounded)
                _lookSameWay();

        //pulo
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpforce);

        }
    }

    void flip()
    {
        if (!_facingRight)
        transform.eulerAngles = new Vector3(0, 0, 0);
        
        else
        transform.eulerAngles = new Vector3(0, 180, 0);


        _facingRight = !_facingRight;
    }

    void _lookSameWay()
    {
        if (!_facingRight)           
            transform.eulerAngles = new Vector3(0, 180, 0);
        else
            transform.eulerAngles = new Vector3(0, 0, 0);
    }



    private void FixedUpdate()
    {
        movecharacter(movement);

        GroundCheck();

        _rigidbody.AddForce(Vector3.down * _extragravity * Time.deltaTime);
    
    
    }

    void movecharacter(Vector2 direction)
    {
        
        _rigidbody.MovePosition((Vector2)transform.position + (direction * _movementforce * Time.deltaTime));
        

    }

    void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector2.down, _distToGround))
        {
            _isGrounded = true;
            debug.text = "Grounded";
        }
        else
        {
            _isGrounded = false;
            debug.text = "Not Grounded";
        }
    }

}

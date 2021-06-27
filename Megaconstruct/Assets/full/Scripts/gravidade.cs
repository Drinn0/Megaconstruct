using UnityEngine;
using System.Collections;

public class gravidade : MonoBehaviour
{

    private CharacterController cc;
    public float MoveSpeed;
    public float RotationSpeed;
    public float gravity;
    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        Vector3 foward = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * MoveSpeed;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0));
        if (!cc.isGrounded)
            foward.y -= gravity * Time.deltaTime;

        cc.Move(foward * Time.deltaTime);


    }

}

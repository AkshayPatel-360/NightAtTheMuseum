using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody rb;
    public float playerMovementSpeed;
    public AnimationCurve animationCurve;
    public float playerJump;
    public Transform camara;
    //float distToGround;
    // Start is called before the first frame update

    private void Awake()
    {
        rb =  gameObject.GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Start()
    {
        //distToGround = collider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();       
        Jump();
    }

    void PlayerMovement()
    {
        if(Input.GetKey(KeyCode.W) )
        {
            
            rb.AddForce(camara.forward * playerMovementSpeed , ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            
            rb.AddForce(-camara.forward * playerMovementSpeed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {

            rb.AddForce(-camara.right * playerMovementSpeed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {

            rb.AddForce(camara.right * playerMovementSpeed, ForceMode.Force);
        }
    }

    void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(new Vector3(0, -1, 0) * playerMovementSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(new Vector3(0, 1, 0) * playerMovementSpeed, ForceMode.Force);
        }
    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) )
        {
            rb.AddForce(transform.up * playerJump, ForceMode.Force);
        }
    }

}

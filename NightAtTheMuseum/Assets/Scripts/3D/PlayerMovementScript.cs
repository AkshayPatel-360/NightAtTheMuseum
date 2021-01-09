using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float maxSpeed;
    public float acceleration;
    Rigidbody rb;
    
    Animator animator;
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
       // animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementWASD();

        //animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));



    }

    void PlayerMovementWASD()
    {
        float vertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        Vector3 movementVector = new Vector3(horizontal, 0f, vertical).normalized;
        // transform.eulerAngles += new Vector3(-vertical, horizontal, 0);
        //transform.eulerAngles += movementVector;
        //rb.AddForce(movementVector, ForceMode.Force);
        //rb.AddForce(movementVector, ForceMode.Force);

        if(movementVector.magnitude >= 0.1f)
        {
           
        }



    }

}

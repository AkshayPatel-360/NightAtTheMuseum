using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMovement : MonoBehaviour
{
    public Rigidbody rb2d;
    public float playerMoveSpeed;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //rb2d = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementAD();
        PlayerAnimations();
        Debug.Log(Mathf.Clamp(rb2d.velocity.z, 0f, 1f));
    }


    void PlayerMovementAD()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector3( playerMoveSpeed * Time.fixedDeltaTime, rb2d.velocity.y, rb2d.velocity.z);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector3(-playerMoveSpeed * Time.fixedDeltaTime, rb2d.velocity.y, rb2d.velocity.z);
        } 

        if (Input.GetKey(KeyCode.W))
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, rb2d.velocity.y,- playerMoveSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb2d.velocity = new Vector3(rb2d.velocity.x, rb2d.velocity.y, playerMoveSpeed * Time.fixedDeltaTime);
        }

        

    }


    void PlayerAnimations()
    {

        //Debug.LogError(rb2d.velocity.z);
         animator.SetFloat("Vertical", Mathf.Clamp(-rb2d.velocity.z ,0f,1f));
        //animator.SetFloat("Horizontal", Mathf.Clamp(-rb2d.velocity.x, 0f, 1f));


    }
}

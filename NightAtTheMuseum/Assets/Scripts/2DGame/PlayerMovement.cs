using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float playerMoveSpeed;
    public float playerJump;  
    Renderer rend;

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        PlayerMovementAD();
        
    }
    private void Update()
    {
        
        Vector2 bottom = rend.bounds.min;
        RaycastHit2D hit = Physics2D.Raycast(bottom, -Vector2.up,0.3f);
        //Debug.DrawRay(bottom, -Vector2.up * 0.3f,Color.red,1);          
        if (hit.collider != null && (Input.GetKey(KeyCode.Space)))
        {
            Jump();
        }

    }

    void PlayerMovementAD()
    {
        float xmove = Input.GetAxisRaw("Horizontal");
        
        rb2d.velocity = new Vector2(xmove * playerMoveSpeed, rb2d.velocity.y);
    }

    void Jump()
    {      
        rb2d.velocity = new Vector2(rb2d.velocity.x, playerJump );
    }

}

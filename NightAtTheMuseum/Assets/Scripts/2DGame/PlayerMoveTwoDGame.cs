using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTwoDGame : MonoBehaviour
{
    private Rigidbody2D rb;
    [Tooltip("Movement Speed in range on (10~20)")] [SerializeField] private float MovementSpeed;
    [Tooltip("Jump Force In Range Of (3~8)")] [SerializeField] private float jumpForce;
    float x, moveBy;
    public float distanceFromGround;
    //private bool isItGround = false;
    [Header("Specify The Layer")]
    public LayerMask groundLayer;
    Vector2 position, direction;
    bool IsGrounded()
    {
        position = transform.position;
        direction = Vector2.down;

        Debug.DrawRay(position, direction * distanceFromGround, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distanceFromGround, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerAnimation();
        Move();
        Jump();
    }

    public void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        moveBy = x * MovementSpeed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void Jump()
    {

        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }
}

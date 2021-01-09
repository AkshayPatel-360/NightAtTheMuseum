using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorControllerScript : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed;
    public float gravity = 9.81f;
    public float jumpSpeed;
    private float directionY;
    private bool canDoubleJump = false;
    public float doubleJumpMultipler = 1f;
    public Animator animator;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelo;
    public Transform cam;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput) ;
        

        if (controller.isGrounded)
        {
            canDoubleJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                directionY = jumpSpeed ;
                animator.SetFloat("Jump", Mathf.Clamp(directionY, 0, 1));
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                directionY = jumpSpeed * doubleJumpMultipler;
                animator.SetFloat("Jump", Mathf.Clamp(directionY, 0, 1));
                canDoubleJump = false;
            }
        }

        if(direction.magnitude>= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelo, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }


        directionY -= gravity * Time.deltaTime;

        direction.y = directionY; 
        controller.Move(direction * Time.deltaTime * moveSpeed);

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
       
    }
}

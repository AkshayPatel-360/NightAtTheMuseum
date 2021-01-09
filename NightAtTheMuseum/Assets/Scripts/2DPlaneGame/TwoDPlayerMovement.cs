using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDPlayerMovement : MonoBehaviour
{
    public SpriteRenderer playerBounds;
    public float playerSpeed;
    Bounds targetBounds;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        targetBounds = playerBounds.bounds;
        GameObject.Destroy(playerBounds.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MovementAD();
    }

    void MovementAD()
    {
        float vertical = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;
        Vector3 newPos = new Vector3(horizontal, vertical,0) + transform.position;
       
        if (targetBounds.Contains(newPos))
        {
            transform.position = newPos;
        }
    }

}
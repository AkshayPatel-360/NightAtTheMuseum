using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("FallingPlatform"))
        {
            Invoke("DropPlatform", 1f);
            Destroy(collision.gameObject,20f);
        }
    }

    void DropPlatform()
    {
       //rb.bodyType = Dynamic;
    }
}

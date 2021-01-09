using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{

    public float bulletSpeed;
    public SpriteRenderer bulletBounds;
    Bounds targetBounds;
    public float deathtime = 1f;
    public GameObject gameOvvverrr;
    float timer;
    void Start()
    {
        timer = 0f;
        targetBounds = bulletBounds.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += Vector3.down * bulletSpeed * Time.deltaTime;
        if (timer > deathtime)
        {
            DistroyBullet();
        }

       
    }

    void DistroyBullet()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOvvverrr.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(collision.gameObject);          
        }
    }
}

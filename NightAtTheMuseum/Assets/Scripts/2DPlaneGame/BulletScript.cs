using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletSpeed;
    public SpriteRenderer bulletBounds;
    public GameObject gameOvvverrr;
    public AudioSource audio;

    Bounds targetBounds;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        // bulletBounds = GameObject.Find("PlayerBounds").GetComponent<SpriteRenderer>();
        targetBounds = bulletBounds.bounds;
    }

    // Update is called once per frame
    void Update()
    {

        DistroyBullet();
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
    }

    void DistroyBullet()
    {
        if (!targetBounds.Contains(gameObject.transform.position))
        {

            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audio.Play();
            Destroy(collision.gameObject);
        }
    }
















}

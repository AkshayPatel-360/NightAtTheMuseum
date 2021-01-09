using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float fireRate;
    float timer;
    public GameObject bullet;
    public GameObject firePoint;
    public TwoDPlayerMovement tpm;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
        tpm = GetComponent<TwoDPlayerMovement>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {       
        if(timer<Time.time && Input.GetKey(KeyCode.Space))
        {
            timer = Time.time + fireRate;
            GameObject gg =  Instantiate(bullet, firePoint.transform.position, Quaternion.identity); // GameObject.Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            audio.Play();
        }
    }

    
}

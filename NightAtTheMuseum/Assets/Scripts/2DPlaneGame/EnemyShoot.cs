using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public float fireRate;
    float timer;
    public GameObject bullet;
    public GameObject firePoint;
    private GameObject gameOverScreen;
    void Start()
    {
        timer = 1f;
        gameOverScreen = GameObject.Find("PanelParent");
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        timer -=timer *Time.deltaTime;
        if (timer <= 0.1f )
        {
           
            GameObject gg = Instantiate(bullet, firePoint.transform.position, Quaternion.identity); // GameObject.Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            gg.GetComponent<EnemyBulletScript>().gameOvvverrr = gameOverScreen;
            timer = 0.5f;
        }
    }
}

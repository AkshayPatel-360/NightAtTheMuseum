using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float fireRate;
    GameObject bulletObj;
    public float firePower;
    public float distanceFromPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
        bulletObj = Resources.Load<GameObject>("Entities/Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            GameObject go = Instantiate(bulletObj) ;
            go.transform.position = transform.position * distanceFromPlayer;
            go.GetComponent<Rigidbody>().AddForce(transform.forward * firePower) ;               
        }
    }
}

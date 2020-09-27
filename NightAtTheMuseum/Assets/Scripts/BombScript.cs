using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float fusetime;
    public float force;
    public float range;
    public float upwerdForce;
    AudioSource ad;
    void Start()
    {
        ad = gameObject.GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        InvockBombTimer();
    }

    void DetonateBomb()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, range);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //float individualForce = hit.transform.position.sqrMagnitude - range;
                rb.AddExplosionForce(  force, explosionPosition, range, upwerdForce, ForceMode.Impulse);
            }
            
        }
        ad.Play();
        Destroy(gameObject);
        
    }

    
    public void InvockBombTimer()
    {
        Invoke("DetonateBomb", fusetime);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("2DGame");
    }

    // Update is called once per frame
    void Update()
    {
        //loadNextScne();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
        }
       
    }

    private void loadNextScne()
    {
        SceneManager.LoadScene("2DGame");
    }




}

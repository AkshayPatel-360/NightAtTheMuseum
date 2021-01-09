using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RendomCardSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Button redButton;
    public Button greenButton;
    public GameObject content;
    void Start()
    {
        redButton = Instantiate(redButton, content.transform);
        greenButton = Instantiate(greenButton, content.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

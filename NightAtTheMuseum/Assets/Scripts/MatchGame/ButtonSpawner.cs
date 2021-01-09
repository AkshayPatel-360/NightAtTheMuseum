using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Button yourButton;
    GameObject marchentContent;
    public GameObject button;

    void Start()
    {
        
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");

        button.transform.SetParent(marchentContent.transform);



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonforBomb : MonoBehaviour
{
    public Button yourButton; 
    // Start is called before the first frame update
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
        BombScript bs = new BombScript();
        bs.InvockBombTimer();

    }
}

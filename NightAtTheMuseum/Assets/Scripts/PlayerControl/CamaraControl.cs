using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{

    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseInputX = Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;
        float mouseInputY = Input.GetAxisRaw("Mouse Y") * rotateSpeed * Time.deltaTime;

        transform.eulerAngles += new Vector3(-mouseInputY, mouseInputX, 0);
    }
}

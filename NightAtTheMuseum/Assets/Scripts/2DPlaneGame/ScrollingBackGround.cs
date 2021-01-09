using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 scrollDirectionAndSpeed;
    Vector2 offset;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       offset += scrollDirectionAndSpeed * Time.deltaTime;
        sr.material.SetTextureOffset("_MainTex", offset);
    }
}

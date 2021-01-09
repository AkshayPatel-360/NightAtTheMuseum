using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float EnemyMoveSpeed;
    public Vector3[] parrentPos;
    public int currentPos;
    public SpriteRenderer EnemyBounds;
    Bounds targetBounds;


    void Start()
    {
       
    }

    
    void Update()
    {
        
        setPosition();
        
    }

    private void setPosition()
    {

        Vector3 direction = (parrentPos[currentPos] - transform.position).normalized;
        
        transform.position += direction * EnemyMoveSpeed * Time.deltaTime;
        float nextPointDistance = Vector2.SqrMagnitude(parrentPos[currentPos] - transform.position);
        
        if (nextPointDistance < .2f)
            currentPos++;
        if (currentPos > parrentPos.Length - 1 )
        {
            Destroy(gameObject);           
        }

    }

    public void SetPath (Transform pattern)
    {
        parrentPos = new Vector3[pattern.childCount];

        for(int i=0; i < pattern.childCount; i++)
        {
            Transform child = pattern.GetChild(i);
            if (child != transform)
                parrentPos[i] = pattern.GetChild(i).position;
        }
    }

    void DistroyEnemy()
    {
        if (!targetBounds.Contains(gameObject.transform.position))
        {
            Destroy(this.gameObject);
        }
    }





}

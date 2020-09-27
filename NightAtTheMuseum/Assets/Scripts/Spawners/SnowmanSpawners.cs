using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanSpawners : MonoBehaviour
{
    public float timeBetweenSpawns = 3;
    float timeOfNextSpawn;
    GameObject resourceObj;


    // Start is called before the first frame update
    void Start()
    {
        timeOfNextSpawn = Time.time + timeBetweenSpawns;
        resourceObj = Resources.Load<GameObject>("Entities/Snowman");
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOfNextSpawn <= Time.time)
        {            
            GameObject go =   GameObject.Instantiate(resourceObj);
            go.transform.position = GetSpawnPos();
            timeOfNextSpawn = timeBetweenSpawns + Time.time;
        }
    }


    private Vector3 GetSpawnPos()
    {
        Vector3 toReturn;
        toReturn = new Vector3(Random.Range(-transform.localScale.x / 2f, transform.localScale.x / 2f),
                               Random.Range(-transform.localScale.y / 2f, transform.localScale.y / 2f),
                               Random.Range(-transform.localScale.z / 2f, transform.localScale.z / 2f))
                                    + transform.position;
        return toReturn;

    }
}

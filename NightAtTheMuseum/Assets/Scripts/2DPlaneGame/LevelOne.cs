using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    public Wave[] waves;
    int currentWave;
    float timeRemainingUntilNextWave;
    bool waveComplete;
    public GameObject[] path;
    private Vector3[] parrentPos;
    private int currentPattern;
    

    void Start()
    {
        currentWave = 0;
        currentPattern = 0;
        timeRemainingUntilNextWave = waves[0].timeToActive;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveComplete)
            return;
        

        UpdateWave(waves[currentWave]);
        timeRemainingUntilNextWave -= Time.deltaTime;
        if(timeRemainingUntilNextWave<=0)
        {
            StartCoroutine(StartWave(waves[currentWave]));
            currentWave++;
            if (currentWave >= waves.Length)
                WaveComplete();
            else
                timeRemainingUntilNextWave = waves[currentWave].timeToActive;
        }
        
            

    }

    IEnumerator StartWave(Wave waveToSpawn)
    {
       
        SpawnPackegs sp = waveToSpawn.spawnPackegs;      
        for (int i  = 0; i < waveToSpawn.spawnPackegs.numberOfSpawn; i++)
        {
            Transform pattern = GetPattern(currentPattern);
            

            GameObject newEnemy = GameObject.Instantiate(sp.enemyResources);

            newEnemy.transform.position = pattern.GetChild(0).position;
            newEnemy.GetComponent<EnemyScript>().SetPath(pattern);
            //newEnemy.transform.position = new Vector2(Random.Range(-5f,5f),9);
           //     
            if (currentPattern> path.Length)
            {
                currentPattern = 0;
            }
            
            yield return new WaitForSeconds(waveToSpawn.spawnPackegs.timeSpacing);
            
        }
        

    }

    private Transform GetPattern(int index)
    {
        return Instantiate(path[index]).transform;
    }


    void UpdateWave( Wave toUpdate)
    {
       // if (Time.time <= waves.Length) ;
       // 

    }
    void WaveComplete()
    {
        waveComplete = true;
    }
}

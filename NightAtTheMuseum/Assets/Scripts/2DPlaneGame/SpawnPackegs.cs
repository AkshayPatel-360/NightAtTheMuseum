using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveScriptableObject", order = 1)]
public class SpawnPackegs : ScriptableObject
{
    public GameObject enemyResources;
    public float timeSpacing;
    public int numberOfSpawn;

}

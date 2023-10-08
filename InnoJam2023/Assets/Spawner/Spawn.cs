using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Spawner;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn : MonoBehaviour
{  
    [SerializeField]
    private GameObject obj;

    [SerializeField] private GameObject spawn;

    public SpawnerConfiguration spawnConfig;

    private float lastSpawned;

    private float spawnInterval = 0.1f;

    public TMP_Text WaveDisplay; 
    
    void Start()
    { 
        lastSpawned = Time.time;
        StartCoroutine(SpawnWaves());
    }

    public IEnumerator SpawnWaves()
    {
        int currentWave = 0;
        while (currentWave < spawnConfig.Waves.Count)
        {
            currentWave++; 
            foreach (var wave in spawnConfig.Waves)
            {
                if (wave.WaveNumber != currentWave)
                {
                    continue;
                } 
                for (int i = 0; i < wave.NumberOfEnemies; i++)
                {
                    Instantiate(wave.EnemyPrefab, spawn.transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(wave.TimeBetweenEnemies);
                } 
                
                yield return new WaitForSeconds(wave.TimeBetweenWaves);
            }
        }
    }
}

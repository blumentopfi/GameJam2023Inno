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
    private EventHandler<int> waveChangeHandler;
    
    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private GameObject spawn;

    public SpawnerConfiguration spawnConfig;

    private float lastSpawned;

    private float spawnInterval = 0.1f;

    public TMP_Text waveDisplay;
    
   public event EventHandler<int> OnWaveChange
   {
       add => waveChangeHandler += value;
       remove => waveChangeHandler -= value;
   } 
    
    void Start()
    {
        waveDisplay.text = $"0/{spawnConfig.Waves.Count()}";
        
        lastSpawned = Time.time;
        StartCoroutine(SpawnWaves());
    }

    public IEnumerator SpawnWaves()
    {
        int currentWave = 0;
        while (currentWave < spawnConfig.Waves.Count)
        {
            currentWave++;
            waveChangeHandler?.Invoke(this, currentWave);
            foreach (var wave in spawnConfig.Waves)
            {
                if (wave.WaveNumber != currentWave)
                {
                    continue;
                }
                
                waveDisplay.text = $"{wave.WaveNumber}/{spawnConfig.Waves.Count()}";
                for (int i = 0; i < wave.NumberOfEnemies; i++)
                {
                    Instantiate(wave.EnemyPrefab, spawn.transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(wave.TimeBetweenEnemies);
                }
                Instantiate(wave.EndOfWaveMarker, spawn.transform.position, Quaternion.identity);
                
                yield return new WaitForSeconds(wave.TimeBetweenWaves);
            }
        }
    }
}

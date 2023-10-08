using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Spawner
{
    public class WaveByWaveSpawner : MonoBehaviour
    {
        private EventHandler<WaveFinishedEventArgs> waveFinishedHandler;
        
        public SpawnerConfiguration spawnConfig;

        private List<GameObject> spawnedEnemies;

        private int waveIndex = 0;
        private int enemiesReachedGoal = 0;
        private int enemyKillCount = 0;
        private BabyHealth babyHealth;

        [SerializeField] private GameObject spawn;
         
        public event EventHandler<WaveFinishedEventArgs> OnWaveFinished
        {
            add => waveFinishedHandler += value;
            remove => waveFinishedHandler -= value;
        } 
        
        private void Awake()
        {
            spawnedEnemies = new();
        }

        private void Start()
        {
            babyHealth = FindObjectOfType<BabyHealth>();
            StartCoroutine(SpawnNextWave());
        }

        private IEnumerator SpawnNextWave()
        {
            if (waveIndex >= spawnConfig.Waves.Count)
            {
                yield break;
            } 
            enemiesReachedGoal -= enemiesReachedGoal;
            enemyKillCount = 0;
            
            var wave = spawnConfig.Waves[waveIndex];
            for (int i = 0; i < wave.NumberOfEnemies; i++)
            {
                var obj = Instantiate(wave.EnemyPrefab, spawn.transform.position, Quaternion.identity);
                spawnedEnemies.Add(obj);
                obj.GetComponent<EnemyHealth>().OnDeath += OnEnemyDeath; 
                obj.GetComponent<UnitMovement>().OnReachedGoal += OnEnemyReachedGoal; 
                
                yield return new WaitForSeconds(wave.TimeBetweenEnemies);
            }

            waveIndex++;
        }

        private void OnEnemyReachedGoal(object sender, EventArgs e)
        {
            enemiesReachedGoal++;
            RemoveEnemyFromList(sender as GameObject);
        }

        private void OnEnemyDeath(object sender, EventArgs e)
        {
            enemyKillCount++;
            RemoveEnemyFromList(sender as GameObject);
        } 
        private void RemoveEnemyFromList(GameObject enemy)
        {
            if (spawnedEnemies.Contains(enemy))
            {
                spawnedEnemies.Remove(enemy);
                if (spawnedEnemies.Count == 0)
                {
                    if (waveIndex >= spawnConfig.Waves.Count)
                    {
                        //Last wave ended
                        CrossSceneInformation.TraumaLevel = babyHealth.GetBabyHealth();
                        Debug.Log("Game Over");
                        return;
                    }
                    
                    var waveSize = spawnConfig.Waves[waveIndex].NumberOfEnemies;
                    waveFinishedHandler?.Invoke(
                        this, 
                        new WaveFinishedEventArgs(
                            waveSize, 
                            waveIndex,
                            enemyKillCount, 
                            enemiesReachedGoal
                        )
                    );
                    StartCoroutine(SpawnNextWave());
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private List<List<GameObject>> spawnedEnemies;

        private int waveIndex = 0;
        private int enemiesReachedGoal = 0;
        private int enemyKillCount = 0;

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
            StartCoroutine(SpawnNextWave());
        }

        private IEnumerator SpawnNextWave()
        { 
            while (waveIndex < spawnConfig.Waves.Count())
            {
                spawnedEnemies.Add(new List<GameObject>());

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
                    spawnedEnemies[waveIndex].Add(obj);
                    obj.GetComponent<EnemyHealth>().OnDeath += OnEnemyDeath;
                    obj.GetComponent<UnitMovement>().OnReachedGoal += OnEnemyReachedGoal;

                    yield return new WaitForSeconds(wave.TimeBetweenEnemies);
                }

                waveIndex++;
                yield return new WaitForSeconds(wave.TimeBetweenWaves);
            }
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
            foreach (var wave in spawnedEnemies)
            {
                if (wave.Contains(enemy))
                {
                    wave.Remove(enemy);
                    if (wave.Count == 0)
                    {
                        if (waveIndex >= spawnConfig.Waves.Count)
                        {
                            //Last wave ended
                            Debug.Log("Game Over");
                            return;
                        }

                        waveFinishedHandler?.Invoke(
                            this,
                            new WaveFinishedEventArgs(
                                spawnConfig.Waves[waveIndex].NumberOfEnemies,
                                waveIndex,
                                enemyKillCount,
                                enemiesReachedGoal
                            )
                        );
                    }
                } 
            }
        }
    }
}
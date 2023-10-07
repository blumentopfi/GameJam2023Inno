using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spawner
{
    public class WaveByWaveSpawner : MonoBehaviour
    {
        public SpawnerConfiguration spawnConfig;

        private List<GameObject> spawnedEnemies;

        private int waveIndex = 0;

        [SerializeField] private GameObject spawn;

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
            if (waveIndex >= spawnConfig.Waves.Count)
            {
                yield break;
            }
            
            var wave = spawnConfig.Waves[waveIndex];
            for (int i = 0; i < wave.NumberOfEnemies; i++)
            {
                var obj = Instantiate(wave.EnemyPrefab, spawn.transform.position, Quaternion.identity);
                spawnedEnemies.Add(obj);
                obj.GetComponent<EnemyHealth>().OnDeath += OnEnemyDestroy;
                obj.GetComponent<UnitMovement>().OnReachedGoal += OnEnemyDestroy;
                yield return new WaitForSeconds(wave.TimeBetweenEnemies);
            }

            waveIndex++;
        }

        private void OnEnemyDestroy(object sender, EventArgs e)
        {
            var enemy = sender as GameObject;
            if (spawnedEnemies.Contains(enemy))
            {
                spawnedEnemies.Remove(sender as GameObject);
                if (spawnedEnemies.Count == 0)
                {
                    StartCoroutine(SpawnNextWave());
                }
            }
        }
    }
}
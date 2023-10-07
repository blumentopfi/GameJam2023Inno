using System.Collections;
using System.Collections.Generic;
using Spawner;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private GameObject spawn;

    public SpawnerConfiguration spawnConfig;

    private float lastSpawned;

    private float spawnInterval = 0.1f;
    void Start()
    {
        lastSpawned = Time.time;
        StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave()
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

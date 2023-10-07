using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spawner
{
    [CreateAssetMenu(fileName = "SpawnerConfiguration", menuName = "ScriptableObjects/Spawner/SpawnerConfiguration")]
    public class SpawnerConfiguration : ScriptableObject
    {
       public List<WaveData> Waves;
    }
    
    [System.Serializable]
    public struct WaveData
    {
        public int WaveNumber;
        public int NumberOfEnemies;
        public float TimeBetweenEnemies;
        public float TimeBetweenWaves;
        [FormerlySerializedAs("EnemyPrefabs")] public GameObject EnemyPrefab;
    }
}
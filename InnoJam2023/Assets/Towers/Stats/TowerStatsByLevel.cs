using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Towers
{
    [CreateAssetMenu(fileName = "TowerStats", menuName = "ScriptableObjects/TowerStats", order = 1)]
    public class TowerStatsByLevel : ScriptableObject
    {
        public string _name;
        
        [SerializeField]
        public List<TowerStats> _towerStats;

        public int MaxLevel => _towerStats.Count;

        public TowerStats GetStatsForLevel(int level)
        {
            return _towerStats
                .First(stat => stat.Level == level);
        }
    }
    
    [Serializable]
    public struct TowerStats
    {
        public int Level;
        public int Range;
        public int UpgradeCost; 
        public List<IStatComponent> StatComponents;
        
        public T GetStatComponent<T>() where T : IStatComponent
        {
            return (T) StatComponents
                .First(component => component.GetType() == typeof(T));
        }
    }
}
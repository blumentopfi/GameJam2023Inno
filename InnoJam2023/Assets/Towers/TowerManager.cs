using System;
using System.Collections;
using UnityEngine;

namespace Towers
{
    [RequireComponent(typeof(TowerTarget))]
    [RequireComponent(typeof(TowerAttack))]
    public class TowerManager : MonoBehaviour
    {
        [SerializeField]
        private TowerStatsByLevel _towerStatsByLevel;
        
        private TowerStats _towerStats;
        private TowerTarget _towerTarget;
        private TowerAttack _towerAttack;
        private int level;

        private void Start()
        {
            StartCoroutine(UpdateTarget());
            _towerTarget = GetComponent<TowerTarget>();
        }

        public void Construct(int level)
        {
            this.level = level;
            UpdateTowerStats();
        }

        private void Update()
        {
            if (_towerTarget.Target != null)
            {
                _towerAttack.Attack(_towerTarget.Target, _towerStats);
            }
        }

        private void UpdateTowerStats() 
        {
            _towerStats = _towerStatsByLevel.GetStatsForLevel(level);
        }
        
        IEnumerator UpdateTarget()
        {
            while (true)
            {
                _towerTarget.SearchNewTarget(_towerStats.Range);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
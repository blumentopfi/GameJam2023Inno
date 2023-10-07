using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Towers
{
    [RequireComponent(typeof(TowerTarget))]
    [RequireComponent(typeof(TowerAttack))]
    public class TowerManager : MonoBehaviour
    {
        [SerializeField]
        private TowerStatsByLevel _towerStatsByLevel;
        
        [SerializeField]
        private Button upgradeButton;
        
        [SerializeField]
        private GameObject maxUpgradeLevelReachedText;
        
        private TowerStats _towerStats;
        private TowerTarget _towerTarget;
        private TowerAttack _towerAttack;
        private int level = 1;
        
        public TowerStats TowerStats => _towerStats;

        private void Start()
        {
            _towerTarget = GetComponent<TowerTarget>();
            _towerAttack = GetComponent<TowerAttack>();
            
            upgradeButton.onClick.AddListener(Upgrade);
            
            UpdateTowerStats();
            StartCoroutine(UpdateTarget());
        }

        /**
         * Called via Method
         */
        public void OnSelected()
        {
            EnableUpgradeButton();
        }
        
        public void OnDeselected()
        {
            DisableUpgradeButton();
        }

        public void EnableUpgradeButton()
        {
            if (level >= _towerStatsByLevel.MaxLevel)
            {
                maxUpgradeLevelReachedText.SetActive(true);
                return;
            }
            
            if (upgradeButton.isActiveAndEnabled)
            {
                return;
            }
            
            upgradeButton.gameObject.SetActive(true);
        }


        public void DisableUpgradeButton()
        {
            upgradeButton.gameObject.SetActive(false);
            maxUpgradeLevelReachedText.SetActive(false);
        }
        
        public void Upgrade()
        {
            if (level >= _towerStatsByLevel.MaxLevel)
            {
                return;
            }
            level += 1;
            UpdateTowerStats();
            
            
            if (level >= _towerStatsByLevel.MaxLevel)
            {
                DisableUpgradeButton();
            }
            
            SendMessage("OnUpgrade");
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
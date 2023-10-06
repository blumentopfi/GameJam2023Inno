using System.Collections.Generic;
using UnityEngine;

namespace Towers.Targeting
{
    public class RandomTargetingComponent : MonoBehaviour, ITargetingComponent
    {
        public GameObject GetTarget(List<GameObject> enemiesInRange, Vector3 towerPosition)
        {
            if (enemiesInRange.Count == 0)
            {
                return null;
            }
            var randomIndex = Random.Range(0, enemiesInRange.Count);
            return enemiesInRange[randomIndex];
        }
    }
}
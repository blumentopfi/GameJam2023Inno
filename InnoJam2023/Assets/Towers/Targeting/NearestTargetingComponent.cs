using System.Collections.Generic;
using UnityEngine;

namespace Towers.Targeting
{
    public class NearestTargetingComponent : MonoBehaviour, ITargetingComponent
    {
        public GameObject GetTarget(List<GameObject> enemiesInRange, Vector3 towerPosition)
        {
            GameObject nearestEnemy = null;
            float smallestDistance = Mathf.Infinity;
            foreach (GameObject enemy in enemiesInRange)
            {
                float distanceToEnemy = Vector3.Distance(towerPosition, enemy.transform.position);
                if (distanceToEnemy < smallestDistance)
                {
                    smallestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
            return nearestEnemy;
        }
    }
}
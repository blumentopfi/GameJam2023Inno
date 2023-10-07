using System.Collections.Generic;
using UnityEngine;

namespace Towers.Targeting
{
    [CreateAssetMenu(fileName = "NearestTargetingComponent", menuName = "ScriptableObjects/NearestTargetingComponent")]
    public class NearestTargetingComponent : TargetingComponent
    {
        public override GameObject GetTarget(List<GameObject> enemiesInRange, Vector3 towerPosition)
        {
            GameObject nearestEnemy = null;
            float smallestDistance = Mathf.Infinity;
            foreach (GameObject enemy in enemiesInRange)
            {
                if (!enemy.gameObject.CompareTag("Enemies"))
                {
                    continue;
                }
                
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
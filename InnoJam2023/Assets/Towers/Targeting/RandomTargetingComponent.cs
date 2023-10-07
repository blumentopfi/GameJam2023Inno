using System.Collections.Generic;
using UnityEngine;

namespace Towers.Targeting
{
    [CreateAssetMenu(fileName = "RandomTargetingComponent", menuName = "ScriptableObjects/RandomTargetingComponent")]
    public class RandomTargetingComponent : TargetingComponent
    {
        public override GameObject GetTarget(List<GameObject> enemiesInRange, Vector3 towerPosition)
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
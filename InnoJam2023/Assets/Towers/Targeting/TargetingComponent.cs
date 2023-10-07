using System.Collections.Generic;
using UnityEngine;

namespace Towers.Targeting
{
    public abstract class TargetingComponent : ScriptableObject
    {
        public abstract GameObject GetTarget(List<GameObject> enemiesInRange, Vector3 towerPosition);
    }
}
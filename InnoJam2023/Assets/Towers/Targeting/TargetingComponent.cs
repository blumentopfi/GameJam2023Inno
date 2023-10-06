using System.Collections.Generic;
using UnityEngine;

namespace Towers.Targeting
{
    public interface ITargetingComponent
    {
        public GameObject GetTarget(List<GameObject> enemiesInRange, Vector3 towerPosition);
    }
}
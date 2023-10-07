using System.Collections.Generic;
using UnityEngine;

namespace Towers.WeaponModifier
{
    public abstract class TargetWeaponModifier : WeaponModifier
    {
        public abstract List<GameObject> GetModifiedTargets(List<GameObject> targets, TowerStats statsByLevel);
    }
}
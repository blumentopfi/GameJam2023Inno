using UnityEngine;

namespace Towers.WeaponModifier
{
    public abstract class BuffWeaponModifier : WeaponModifier
    {
        public abstract void ApplyBuff(GameObject target, TowerStats statsByLevel);
    }
}
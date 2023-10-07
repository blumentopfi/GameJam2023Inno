using System.Collections.Generic;
using System.Linq;
using Towers.WeaponModifier;
using UnityEngine;

namespace Towers
{

    [AddComponentMenu("Weapons/DefaultWeapon")]
    public class DefaultWeapon : Weapon
    {
        public override void ShootAt(GameObject target, TowerStats statsByLevel)
        {
            var initialTargets = new List<GameObject> { target };
            var finalTargets = GetModifier<TargetWeaponModifier>()
                .Aggregate(initialTargets,
                    (targets, modifier) => modifier.GetModifiedTargets(targets, statsByLevel));
            

            var buffModifier = GetModifier<BuffWeaponModifier>();
            finalTargets.ForEach(t =>
            {
                buffModifier.ForEach(bm => bm.ApplyBuff(t, statsByLevel));
            });
        }
    }

}
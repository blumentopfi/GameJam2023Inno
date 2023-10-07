using System.Collections;
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
                    (targets, modifier) =>
                    {
                        StartCoroutine(VisualizeAttack(targets, modifier));
                        return modifier.GetModifiedTargets(targets, statsByLevel);
                    });
            

            var buffModifier = GetModifier<BuffWeaponModifier>();
            finalTargets.ForEach(t =>
            {
                buffModifier.ForEach(bm =>
                {
                    StartCoroutine(VisualizeAttack(new List<GameObject> {t}, bm));
                    bm.ApplyBuff(t, statsByLevel);
                });
            });

        }
        
        private IEnumerator VisualizeAttack(List<GameObject> targets, WeaponModifier.WeaponModifier modifier)
        {
            yield return modifier.Visualize(targets);
        }
    }

}
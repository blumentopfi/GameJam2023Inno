using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers.WeaponModifier
{
    [CreateAssetMenu(fileName = "SplashTargetModifier", menuName = "ScriptableObjects/SplashTargetModifier")]
    public class SplashTargetModifier : TargetWeaponModifier
    {
        public override List<GameObject> GetModifiedTargets(List<GameObject> targets, TowerStats statsByLevel)
        {
            var splashRadius = statsByLevel.GetStatComponent<SplashStatComponent>().SplashRange;
            var splashTargets = new List<GameObject>();
            targets.ForEach(t =>
            {
                var colliders = Physics.OverlapSphere(t.transform.position, splashRadius);
                foreach (var collider in colliders)
                {
                    if (collider.gameObject.CompareTag("Enemy"))
                    {
                        splashTargets.Add(collider.gameObject);
                    }
                }
            });
            return splashTargets;
        }

        public override IEnumerator Visualize(List<GameObject> targets)
        {
            throw new System.NotImplementedException();
        }
    }
}
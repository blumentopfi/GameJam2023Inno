using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers.WeaponModifier
{
    [CreateAssetMenu(fileName = "SplashTargetModifier", menuName = "ScriptableObjects/SplashTargetModifier")]
    public class SplashTargetModifier : TargetWeaponModifier
    {
        public GameObject splashEffect;
        public override List<GameObject> GetModifiedTargets(List<GameObject> targets, TowerStats statsByLevel)
        {
            var splashRadius = statsByLevel.GetStatComponent<SplashStatComponent>().SplashRange;
            var splashTargets = new List<GameObject>();
            targets.ForEach(t =>
            {
                var colliders = Physics.OverlapSphere(t.transform.position, splashRadius);
                foreach (var collider in colliders)
                {
                    if (collider.gameObject.CompareTag("Enemies"))
                    {
                        splashTargets.Add(collider.gameObject);
                    }
                }
            });
            return splashTargets;
        }

        public override IEnumerator Visualize(List<GameObject> targets)
        {
            var effects = new List<GameObject>();
            foreach (var target in targets)
            {
                var effect = Instantiate(splashEffect, target.transform.position, Quaternion.identity);
                effects.Add(effect);
            }
            
            yield return new WaitForSeconds(1f);
            
            foreach (var effect in effects)
            {
                Destroy(effect);
            }
        }
    }
}
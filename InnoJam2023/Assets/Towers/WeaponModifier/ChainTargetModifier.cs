using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Towers.WeaponModifier
{
    [CreateAssetMenu(fileName = "ChainTargetModifier", menuName = "ScriptableObjects/ChainTargetModifier")]
    public class ChainTargetModifier : TargetWeaponModifier
    {
        public override List<GameObject> GetModifiedTargets(List<GameObject> targets, TowerStats statsByLevel)
        {
            var chainTargets = new List<GameObject>();
            var chainRadius = statsByLevel.GetStatComponent<ChainStatComponent>().MaxChainRange;
            var chainAmount = statsByLevel.GetStatComponent<ChainStatComponent>().ChainAmount;

            targets.ForEach(t =>
            {
                var colliders = Physics.OverlapSphere(t.transform.position, chainRadius);
                var orderedEnemies = colliders
                    .Where(collider => collider.gameObject.CompareTag("Enemy"))
                    .OrderBy(collider => Vector3.Distance(collider.transform.position, t.transform.position))
                    .Take(chainAmount);
                
                chainTargets.AddRange(orderedEnemies.Select(collider => collider.gameObject));
            });
            return chainTargets;
        }

        public override IEnumerator Visualize(List<GameObject> targets)
        {
            throw new System.NotImplementedException();
        }
    }
}
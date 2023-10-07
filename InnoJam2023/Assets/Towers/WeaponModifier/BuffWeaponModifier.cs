using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers.WeaponModifier
{
    public abstract class BuffWeaponModifier : WeaponModifier
    {
        public GameObject Effect;

        public abstract void ApplyBuff(GameObject target, TowerStats statsByLevel);
        
        public override IEnumerator Visualize(List<GameObject> targets)
        {
            var effects = new List<GameObject>();
            foreach (var target in targets)
            {
                var effect = Instantiate(Effect, target.transform.position, Quaternion.identity);
                effects.Add(effect);
            }
            
            yield return new WaitForSeconds(Effect.GetComponent<ParticleSystem>().main.duration);
            
            foreach (var effect in effects)
            {
                Destroy(effect);
            }
        }
    }
}
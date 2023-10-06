using UnityEngine;

namespace Towers.WeaponModifier
{
    [CreateAssetMenu(fileName = "TakeDamageWeaponModifier", menuName = "ScriptableObjects/TakeDamageWeaponModifier")]
    public class TakeDamageWeaponModifier : BuffWeaponModifier
    {
        public override void ApplyBuff(GameObject target, TowerStats statsByLevel)
        {
            target.GetComponent<EnemyHealth>().TakeDamage(statsByLevel.GetStatComponent<DamageStats>().Damage);
        }
    }
}
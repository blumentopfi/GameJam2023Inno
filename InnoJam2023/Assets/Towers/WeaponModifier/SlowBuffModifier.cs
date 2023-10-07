using UnityEngine;

namespace Towers.WeaponModifier
{
    [CreateAssetMenu(fileName = "SlowBuffModifier", menuName = "ScriptableObjects/SlowBuffModifier")]
    public class SlowBuffModifier : BuffWeaponModifier
    {
        public override void ApplyBuff(GameObject target, TowerStats statsByLevel)
        {
            Debug.LogError("Implementier mich du Hund");
        }
    }
}
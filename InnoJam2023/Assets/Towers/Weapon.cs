using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private List<WeaponModifier.WeaponModifier> weaponModifiers;
        public abstract void ShootAt(GameObject target, TowerStats statsByLevel);
        
        protected List<T> GetModifier<T>() where T : WeaponModifier.WeaponModifier
        {
            var modifiers = new List<T>();
            foreach (var weaponModifier in weaponModifiers)
            {
                if (weaponModifier is T modifier)
                {
                    modifiers.Add(modifier);
                }
            }

            return modifiers;
        }
    }
}
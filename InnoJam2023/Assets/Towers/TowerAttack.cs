using System;
using UnityEngine;

namespace Towers
{
    public class TowerAttack : MonoBehaviour
    {
        private float lastAttack;
        public Weapon Weapon;

        public void Attack(GameObject target, TowerStats statsByLevel)
        {
            var fireRate = statsByLevel.GetStatComponent<DamageStats>().FireRate;
            if (!(Time.time - lastAttack > fireRate))
            {
                return;
            }

            lastAttack = Time.time;
            Weapon.ShootAt(target, statsByLevel);
        }
    }
}
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
            var attackRate = statsByLevel.GetStatComponent<DamageStats>().Damage;
            if (!(Time.time - lastAttack > attackRate))
            {
                return;
            }

            lastAttack = Time.time;
            Weapon.ShootAt(target, statsByLevel);
        }
    }
}
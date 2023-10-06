using System;
using UnityEngine;

namespace Towers
{
    [CreateAssetMenu(fileName = "DamageStatComponent", menuName = "ScriptableObjects/DamageStatComponent")]
    public class DamageStats : IStatComponent
    {
        public float Damage;
        public float FireRate;
    }
}
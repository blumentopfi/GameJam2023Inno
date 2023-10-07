using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers.WeaponModifier
{
    public abstract class WeaponModifier : ScriptableObject
    {
        public abstract IEnumerator Visualize(List<GameObject> targets);
        
    }
}
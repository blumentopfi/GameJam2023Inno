using UnityEngine;

namespace Towers
{
    [CreateAssetMenu(fileName = "SplashStatComponent", menuName = "ScriptableObjects/SplashStatComponent")]
    public class SplashStatComponent : IStatComponent
    {
        public float SplashRange;
    }
}
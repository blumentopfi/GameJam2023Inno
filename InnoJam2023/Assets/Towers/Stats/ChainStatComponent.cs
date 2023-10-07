using UnityEngine;

namespace Towers
{
    [CreateAssetMenu(fileName = "ChainStatComponent", menuName = "ScriptableObjects/ChainStatComponent")]
    public class ChainStatComponent : IStatComponent
    {
        public int ChainAmount;
        public int MaxChainRange;
    }
}
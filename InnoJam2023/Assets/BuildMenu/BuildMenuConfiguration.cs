using System;
using System.Collections.Generic;
using UnityEngine;

namespace BuildMenu
{
    [CreateAssetMenu(fileName = "BuildMenuConfiguration", menuName = "ScriptableObjects/Build/BuildMenuConfiguration")]
    public class BuildMenuConfiguration : ScriptableObject
    {
        public List<BuildMenuConfigurationData> BuildMenuConfigurationData;
    }
    
    [Serializable]
    public struct BuildMenuConfigurationData
    {
        [SerializeField]
        public GameObject TowerPrefab;
        
        [SerializeField]
        public string Name;
        
        [SerializeField]
        public Sprite Icon;
        
        [SerializeField]
        public int Price;
        
    }
}
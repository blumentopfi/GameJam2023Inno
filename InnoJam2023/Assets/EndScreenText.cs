using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EndScreenText : MonoBehaviour
{
        [SerializeField] private TMP_Text endScreen;
        private float traumaLevel => CrossSceneInformation.traumaLevel;
        [SerializeField] private List<kekf> traumas = new();
    
        private void Start()
        {
            kekf randomTrauma = getRandomTraumaLevel(traumaLevel);
            endScreen.text = randomTrauma.text;
        }

        private kekf getRandomTraumaLevel(float leveldecoratorminimumlevel)
        {
            // Filter traumas based on the condition minTrauma > leveldecoratorminimumlevel
            var filteredTraumas = traumas.Where(trauma => trauma.minTrauma > leveldecoratorminimumlevel).ToList();

            // Check if there are any matching traumas
            if (filteredTraumas.Any())
            {
                // Get a random index within the filtered traumas list
                int randomIndex = UnityEngine.Random.Range(0, filteredTraumas.Count);

                // Return the random trauma
                return filteredTraumas[randomIndex];
            }
            else
            {
                // Handle the case when no matching trauma is found (returning an empty struct or default value, etc.)
                return new kekf();
            }
        }
}

[Serializable]
public struct kekf
{
        public int minTrauma;
        public string text;
}

using System;
using System.Collections;
using System.Collections.Generic;
using Spawner;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabyHealth : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;
    private float displayHealth;

    [SerializeField] private TMP_Text traumaDisplay;

    [SerializeField] private SpawnerConfiguration _spawnerConfiguration;

    private void Start()
    {
        for (int i = 0; i < _spawnerConfiguration.Waves.Count; i++)
        {
            var currentWave = _spawnerConfiguration.Waves[i];
            maxHealth += currentWave.NumberOfEnemies * currentWave.EnemyPrefab.GetComponent<EnemyStats>().baseDamage;
        }

        currentHealth = maxHealth;
    }

    void Update()
    {
        displayHealth = Mathf.FloorToInt(currentHealth / maxHealth * 100) ;
            traumaDisplay.text = $"Trauma:{displayHealth}%";
    }

    public void TakeDamage(float damage)    
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public int GetBabyHealth()
    {
        return Mathf.FloorToInt(currentHealth);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabyHealth : MonoBehaviour
{

    [SerializeField]
    private float health;

    [SerializeField] private TMP_Text traumaDisplay;
    
    void Update()
    { 
        traumaDisplay.text = $"Trauma:{health}%";
    }

    public void TakeDamage( float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }

    public int GetBabyHealth()
    {
        return Mathf.FloorToInt(health);
    }
}

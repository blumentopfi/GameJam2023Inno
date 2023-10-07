using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    }

    public int GetBabyHealth()
    {
        return Mathf.FloorToInt(health);
    }
}

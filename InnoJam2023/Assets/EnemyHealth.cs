using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EventHandler deathHandler;

    public EnemyStats enemystats;
    public RectTransform healthBar;
    public DrugManager drugmanager;
    private float health;
    private float maxSize;
    private float maxHealth;

    public event EventHandler OnDeath
    {
        add => deathHandler += value;
        remove => deathHandler -= value;
    }

    void Start()
    {
        maxSize = healthBar.GetComponent<RectTransform>().rect.width;
        drugmanager = FindObjectOfType<DrugManager>();
        health = enemystats.baseHealth;
        maxHealth = enemystats.baseHealth;
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            return;
        }
        
        health -= damage;
        healthBar.sizeDelta = new Vector2(health / maxHealth * maxSize, healthBar.sizeDelta.y);

        if (health <= 0)
        {
            drugmanager.increaseDrugs(enemystats.baseReward);
            deathHandler?.Invoke(gameObject, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
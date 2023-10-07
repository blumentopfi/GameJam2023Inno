using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{


    public EnemyStats EnemyStats;
    public RectTransform healthBar;
    private float health;
    private float maxSize;
    private float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        maxSize = healthBar.GetComponent<RectTransform>().rect.width;
        health = EnemyStats.baseHealth;
        maxHealth = EnemyStats.baseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.sizeDelta = new Vector2(health / maxHealth * maxSize, healthBar.sizeDelta.y);
        // healthBar.GetComponent<Image>().fillAmount = health / maxHealth;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

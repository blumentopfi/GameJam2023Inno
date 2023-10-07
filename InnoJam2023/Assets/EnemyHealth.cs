using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{


    public EnemyStats enemystats;
    public RectTransform healthBar;
    public DrugManager drugmanager;
    private float health;
    private float maxSize;
    private float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        maxSize = healthBar.GetComponent<RectTransform>().rect.width;
        drugmanager = GameObject.FindObjectOfType<DrugManager>();
        health = enemystats.baseHealth;
        maxHealth = enemystats.baseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.sizeDelta = new Vector2(health / maxHealth * maxSize, healthBar.sizeDelta.y);

        if (health <= 0)
        {
            drugmanager.increaseDrugs(enemystats.baseReward);
            Destroy(gameObject);
        }
    }
}

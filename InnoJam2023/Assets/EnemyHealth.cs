using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    public EnemyStats EnemyStats;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        EnemyStats.baseHealth -= damage;

        if (EnemyStats.baseHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

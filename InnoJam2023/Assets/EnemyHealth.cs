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

    void TakeDamage(float damage)
    {

        if (EnemyStats.BaseHealth - damage <= 0)
        {
            Destroy(gameObject);
        }

        EnemyStats.BaseHealth -= damage;
    }
}

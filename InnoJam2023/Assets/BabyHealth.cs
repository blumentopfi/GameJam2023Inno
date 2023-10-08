using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BabyHealth : MonoBehaviour
{

    [SerializeField]
    private float health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage( float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }
}

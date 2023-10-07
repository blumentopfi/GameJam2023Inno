using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    
    [SerializeField]
    private float speed;

    private double tolerance = 0.5;
    private Transform goal;

    public EnemyStats enemystats;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Goal").transform;
        
        agent.speed = speed;
        agent.SetDestination(goal.position);
    }

    // Update is called once per frame
    void Update()
    {

        if ((Math.Abs(agent.transform.position.x - goal.position.x) < tolerance) &&
            (Math.Abs(agent.transform.position.z - goal.position.z) < tolerance))
        {
            var babyHealth = goal.gameObject.GetComponent<BabyHealth>();
            babyHealth.TakeDamage(enemystats.baseDamage);
            Destroy(gameObject);
        }
    }
}

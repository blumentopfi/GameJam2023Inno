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
    private Vector3 goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Goal").transform.position;
        
        agent.speed = speed;
        agent.SetDestination(goal);
    }

    // Update is called once per frame
    void Update()
    {

        if ((Math.Abs(agent.transform.position.x - goal.x) < tolerance) &&
            (Math.Abs(agent.transform.position.z - goal.z) < tolerance))
        {
            Destroy(gameObject);
        }
    }
}

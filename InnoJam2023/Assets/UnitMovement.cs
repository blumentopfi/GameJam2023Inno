using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class UnitMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private double tolerance = 0.6;
    public EnemyStats enemystats;
    private int currentWaypoint;
    private List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = FindObjectOfType<Waypoints>().waypoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < tolerance)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Count)
            {
                var babyHealth = FindObjectOfType<BabyHealth>();
                if (babyHealth != null)
                {
                    babyHealth.TakeDamage(enemystats.baseDamage);
                }

                Destroy(gameObject);
                return;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
    }
}

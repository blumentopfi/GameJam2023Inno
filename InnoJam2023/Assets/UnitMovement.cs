using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class UnitMovement : MonoBehaviour
{
    private EventHandler reachedGoalHandler;

    [SerializeField] private float speed;

    private double tolerance = 0.6;
    public EnemyStats enemystats;
    private int currentWaypoint;
    private List<Transform> waypoints;

    public event EventHandler OnReachedGoal
    {
        add => reachedGoalHandler += value;
        remove => reachedGoalHandler -= value;
    }

    // Start is called before the first frame update
    void Start()
    {
        waypoints = FindObjectOfType<Waypoints>().waypoints;

        GetComponent<MeshRenderer>().material.color = Random
            .ColorHSV(hueMax: 0, hueMin: 1, saturationMax: 1, saturationMin: 1, valueMax: 1, valueMin: 1, alphaMin: 1,
                alphaMax: 1);
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

                reachedGoalHandler?.Invoke(gameObject, EventArgs.Empty);
                Destroy(gameObject);
                return;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position,
            speed * Time.deltaTime);
    }
}
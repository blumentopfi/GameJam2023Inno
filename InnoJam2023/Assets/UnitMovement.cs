using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class UnitMovement : MonoBehaviour
{
    private EventHandler goalReachedHandler;
    
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] dreamSprites;

    private double tolerance = 0.6;
    public EnemyStats enemystats;
    private int currentWaypoint;
    private List<Transform> waypoints;

    public event EventHandler OnReachedGoal
    {
        add => goalReachedHandler += value;
        remove => goalReachedHandler -= value;
    }
    
    void Start()
    {
        waypoints = FindObjectOfType<Waypoints>().waypoints;

        GetComponent<MeshRenderer>().material.color = Random
            .ColorHSV(hueMax: 0, hueMin: 1, saturationMax: 1, saturationMin: 1, valueMax: 1, valueMin: 1, alphaMin: 1,
                alphaMax: 1);

        _spriteRenderer.sprite = dreamSprites[Random.Range(0, dreamSprites.Length)];
    }
    
    public void DecreaseSpeed(float value)
    {
        float minSpeed = 0.5f;
        speed = Mathf.Max(minSpeed, speed * value);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < tolerance)
        {
            if (currentWaypoint >= waypoints.Count-1)
            { 
                var babyHealth = FindObjectOfType<BabyHealth>();
                if (babyHealth != null)
                {
                    babyHealth.TakeDamage(enemystats.baseDamage);
                }

                goalReachedHandler?.Invoke(gameObject, EventArgs.Empty);
                Destroy(gameObject);
                return;
            }
            currentWaypoint++;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position,
            speed * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject obj;

    [SerializeField]
    private GameObject spawn;

    private float lastSpawned;

    private float spawnInterval = 0.1f;
    void Start()
    {
        Instantiate(obj, spawn.transform.position, Quaternion.identity);
        lastSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(Time.time - lastSpawned > spawnInterval)) return;
        Instantiate(obj, spawn.transform.position, Quaternion.identity);
        lastSpawned = Time.time;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Spawner;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemController : MonoBehaviour
{
    public enum tendency
    {
        neutral,
        nice,
        wasted
    }

    public int[] wavesAgeUp;

    private int currentWaveCount = 1;
    private int maxWaveCount = 15;
    private tendency currentTendency = tendency.neutral;

    private int maxLife = 100, newLife;
    private BabyHealth health;

    private ItemUpdater[] updateableItems;
    private List<ItemUpdater> itemsList;


    [SerializeField] private bool demoRun;
    [SerializeField] private int goToLevel = 0;
    [SerializeField] private tendency demoTendency = tendency.wasted;

    [SerializeField] private WaveByWaveSpawner spawner;

    [SerializeField] private Light light;

    private void Awake()
    {
        spawner.OnWaveFinished += OnWaveFinished;
        itemsList = new();
    }

    void Start()
    {
        health = FindObjectOfType<BabyHealth>();
        updateableItems = FindObjectsByType<ItemUpdater>(FindObjectsSortMode.None);

        maxWaveCount = spawner.spawnConfig.Waves.Count;

        foreach (var t in updateableItems)
        {
            itemsList.Add(t);
        }
    }

    private void OnWaveFinished(object sender, WaveFinishedEventArgs args)
    { 
        if (wavesAgeUp.Contains(args.WaveIndex))
        {
            UpdateAge();
        }

        UpdateItems(
            args.WaveSize,
            args.EnemyKillCount,
            args.EnemyReachedGoalCount
        );
    }

    public void UpdateAge()
    {
        foreach (var updateableItem in updateableItems)
        {
            updateableItem.UpdateAge();
        }
    }

    private void UpdateItems(int waveSize, int enemiesKilled, int enemiesReachedGoal)
    {
        if (waveSize <= 0)
        {
            return;
        }
        var successRate =   (float) enemiesKilled/waveSize; 
        var itemsChangeWastedSize = successRate * updateableItems.Length;
        for (int i = 0; i < itemsChangeWastedSize; i++)
        {
            var randomIndex = Mathf.FloorToInt(Random.Range(0, itemsList.Count));
            itemsList.ElementAt(randomIndex).ChooseNextModel(tendency.wasted);
            itemsList.RemoveAt(randomIndex);
        }

        var itemsChangeNiceSize = itemsList.Count;
        for (int i = 0; i < itemsChangeNiceSize; i++)
        {
            var randomIndex = Mathf.FloorToInt(Random.Range(0, itemsList.Count));
            itemsList.ElementAt(randomIndex).ChooseNextModel(tendency.nice);
            itemsList.RemoveAt(randomIndex);
        }

        // Reset List
        foreach (var t in updateableItems)
        {
            itemsList.Add(t);
        }
    }
}
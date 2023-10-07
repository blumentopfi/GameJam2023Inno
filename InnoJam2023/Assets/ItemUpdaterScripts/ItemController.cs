using System;
using System.Linq;
using Spawner;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public enum tendency
    {
        neutral,
        nice,
        wasted
    }

    public int[] wavesCharLevelsUp;
    public int[] wavesRoomUpdates;

    private int currentWaveCount = 1;
    private int maxWaveCount = 15;
    private tendency currentTendency = tendency.neutral;

    private int maxLife = 100, newLife;
    private BabyHealth health;
    
    private ItemUpdater[] updateableItems;
    private ItemUpdaterChild childItem;

    [SerializeField] private bool demoRun;
    [SerializeField] private int goToLevel = 0;
    [SerializeField] private tendency demoTendency = tendency.wasted;

    [SerializeField] private Spawn spawner;

    private void Awake()
    {
        spawner.OnWaveChange += OnWaveChange;
    }
 
    void Start()
    {
        health = FindObjectOfType<BabyHealth>(); 

        maxWaveCount = spawner.spawnConfig.Waves.Count;

        childItem = FindObjectOfType<ItemUpdaterChild>();
        updateableItems = FindObjectsByType<ItemUpdater>(FindObjectsSortMode.None);

        if (demoRun)
        {
            for (int i = goToLevel - 1; i > 0; i--)
            {
                foreach (var updateableItem in updateableItems)
                {
                    updateableItem.ChooseNextModel(demoTendency, true);
                }
            }
        }
    }

    private void OnWaveChange(object sender, int e)
    {
        if (wavesRoomUpdates.Contains(e))
        {
            newLife = health.GetBabyHealth();
            currentTendency = CalculateCurrentTendency();
            UpdateItemController(); 
        }
    }

    public void UpdateItemController()
    {
        currentWaveCount++;
        var charLevelsUp = wavesCharLevelsUp.Contains(currentWaveCount);
          
        if (charLevelsUp)
        {
          childItem.ChooseNextModel(currentTendency, true);
        }

        foreach (var updateableItem in updateableItems)
        {
            updateableItem.ChooseNextModel(currentTendency, charLevelsUp);
        }
    }

    private tendency CalculateCurrentTendency()
    {
        //TODO: Rework
        var lifePerc = newLife/maxLife;
        var wavePerc = currentWaveCount / maxWaveCount;
        if (lifePerc > wavePerc)
        {
            return tendency.wasted;
        } 
        
        if (lifePerc == wavePerc)
        {
            return tendency.neutral;
        }

        return tendency.nice;
    }
}
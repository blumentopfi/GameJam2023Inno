using System.Linq;
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
    public int[] wavesNothingHappens;

    private int currentWaveCount = 1;
    private tendency currentTendency = tendency.neutral;

    private ItemUpdater[] updateableItems;
    private ItemUpdaterChild childItem;

    [SerializeField] private bool demoRun;
    [SerializeField] private int goToLevel = 0;
    [SerializeField] private tendency demoTendency = tendency.wasted;


    // Start is called before the first frame update
    void Start()
    {
        updateableItems = GameObject.FindObjectsByType<ItemUpdater>(FindObjectsSortMode.None);

        if (demoRun)
        {
            for (int i = goToLevel-1; i > 0; i--)
            {
                foreach (var updateableItem in updateableItems)
                {
                    updateableItem.ChooseNextModel(demoTendency, true);
                }
            }
        }
    }

    public void UpdateItemController(int maxPointsOfWave, int actualPointsOfWave)
    {
        currentWaveCount++;
        var charLevelsUp = wavesCharLevelsUp.Contains(currentWaveCount);
        if (wavesNothingHappens.Contains(currentWaveCount))
        {
            return;
        }

        currentTendency = CalculateCurrentTendency(maxPointsOfWave, actualPointsOfWave);
        if (currentTendency == tendency.neutral && !wavesCharLevelsUp.Contains(currentWaveCount))
        {
            return;
        }

        if (charLevelsUp)
        {
            childItem.ChooseNextModel(currentTendency, true);
        }

        foreach (var updateableItem in updateableItems)
        {
            updateableItem.ChooseNextModel(currentTendency, charLevelsUp);
        }
    }

    private tendency CalculateCurrentTendency(int maxPoints, int actualPoints)
    {
        var percentage = actualPoints / maxPoints;
        if (percentage >= 0.67)
        {
            return tendency.wasted;
        }

        if (percentage < 0.67 && percentage >= 0.34)
        {
            return tendency.neutral;
        }

        return tendency.nice;
    }
}
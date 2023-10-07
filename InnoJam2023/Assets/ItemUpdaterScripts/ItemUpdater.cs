using System;
using UnityEngine;

public class ItemUpdater : MonoBehaviour
{
    [SerializeField] private GameObject
        modelBabyWasted,
        modelBabyNeutral,
        modelBabyNice,
        modelChildWasted,
        modelChildNeutral,
        modelChildNice,
        modelTeenWasted,
        modelTeenNeutral,
        modelTeenNice;

    // models[level][state], higher state->more nicer
    private GameObject[,] models = new GameObject[3, 3];

    private int[] currentlyChosen = { 0, 0 }, newChosen = { 0, 0 };

    private void Start()
    {
        models[0, 0] = modelBabyWasted;
        models[0, 1] = modelBabyNeutral;
        models[0, 2] = modelBabyNice;

        models[1, 0] = modelChildWasted;
        models[1, 1] = modelChildNeutral;
        models[1, 2] = modelChildNice;

        models[2, 0] = modelTeenWasted;
        models[2, 1] = modelTeenNeutral;
        models[2, 2] = modelTeenNice;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                models[i, j].gameObject.SetActive(false); 
            } 
        }

        ChooseNextModel(ItemController.tendency.neutral, false);
    }

    public void ChooseNextModel(ItemController.tendency tendency, bool levelsUp)
    {
        if (levelsUp)
        {
            newChosen[0] = currentlyChosen[0] + 1;
        }

        if (tendency == ItemController.tendency.neutral)
        {
            newChosen[1] = currentlyChosen[1];
        }

        if (tendency == ItemController.tendency.nice && currentlyChosen[1] <= 2)
        {
            newChosen[1] = currentlyChosen[1] + 1;
        }

        if (tendency == ItemController.tendency.wasted && currentlyChosen[1] > 0)
        {
            newChosen[1] = currentlyChosen[1] - 1;
        }

        UpdateModel();
    }

    private void UpdateModel()
    {
        // Remember: models[level][state], higher state->more nicer
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                models[i, j].gameObject.SetActive(false); 
            } 
        }
        models[newChosen[0],newChosen[1]].gameObject.SetActive(true);
        currentlyChosen = newChosen;
    }
}
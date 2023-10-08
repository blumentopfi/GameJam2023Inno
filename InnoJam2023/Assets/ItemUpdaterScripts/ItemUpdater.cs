using System;
using UnityEngine;

public class ItemUpdater : MonoBehaviour
{
    [SerializeField] private GameObject
        modelBaby,
        modelChildWasted,
        modelChildNeutral,
        modelChildNice,
        modelTeenWasted,
        modelTeenNeutral,
        modelTeenNice;

    // models[level][state], higher state->more nicer
    private GameObject[,] models = new GameObject[3, 3];

    private int chosenAge = 0;
    private int chosenState = 1;

    private void Start()
    {
        models[0, 0] = modelBaby;
        models[0, 1] = modelBaby;
        models[0, 2] = modelBaby;

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

        ChooseNextModel(ItemController.tendency.neutral);
    }

    public void UpdateAge()
    {
        if (chosenAge >= 2)
        {
            return;
        }

        chosenAge++; 
    }
    public void ChooseNextModel(ItemController.tendency tendency)
    { 
        if (tendency == ItemController.tendency.nice && chosenState < 2)
        {
            chosenState++;
        }

        if (tendency == ItemController.tendency.wasted && chosenState > 0)
        {
            chosenState--;
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
        models[chosenAge, chosenState].gameObject.SetActive(true);  
    }
    
}
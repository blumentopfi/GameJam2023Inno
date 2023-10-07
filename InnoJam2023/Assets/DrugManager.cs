using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugManager : MonoBehaviour
{

    private float drugs = 200;

    public Text drugDisplay;

    private void Start()
    {
        
    }

    private void Update()
    {
        string[] temp = drugDisplay.text.Split('$');
        drugDisplay.text = temp[0] + '$' + drugs;
    }
    
    public void decreaseDrugs(float price)
    {
        drugs -= price;
    }

    public void increaseDrugs(float reward)
    {
        drugs += reward;
    }

    public bool canBuild(float cost)
    {
        
        if (drugs - cost < 0)
        {
            return false;
        }
        return true;
    }
}

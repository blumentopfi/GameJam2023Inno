using System;
using System.Collections;
using System.Collections.Generic;
using BuildMenu;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuTowerButtonView : MonoBehaviour
{
    
    [SerializeField]
    private Button _button ;
    
    [SerializeField]
    private TMP_Text _text;
    
    [SerializeField]
    private Image _image;

    public void SetData(BuildMenuConfigurationData data, Action onBuildClicked)
    {
        _text.text = data.Price.ToString();
        _image.sprite = data.Icon;
        
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(onBuildClicked.Invoke);
    }
}

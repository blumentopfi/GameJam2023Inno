using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    
    public GameObject RangeIndicatorImage;

    public void OnSelected()
    {
        var range = GetComponent<TowerManager>().TowerStats.Range;
        RangeIndicatorImage.transform.localScale = new Vector3(0.4f * range, 0.4f*range, 1);
        RangeIndicatorImage.gameObject.SetActive(true);
    }

    public void OnDeselected()
    {
        RangeIndicatorImage.SetActive(false);
    }

    public void OnUpgrade()
    {
        var range = GetComponent<TowerManager>().TowerStats.Range;
        RangeIndicatorImage.transform.localScale = new Vector3(0.4f * range, 0.4f*range, 1);
    }
}

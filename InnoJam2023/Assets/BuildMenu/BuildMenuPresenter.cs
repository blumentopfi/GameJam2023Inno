using System.Collections;
using System.Collections.Generic;
using BuildMenu;
using UnityEngine;

public class BuildMenuPresenter : MonoBehaviour
{
    private List<BuildMenuTowerButtonView> BuildMenuTowerButtonViews;

    [SerializeField] private BuildMenuConfiguration _buildMenuConfiguration;

    [SerializeField] private BuildMenuTowerButtonView viewInstance;
    
    [SerializeField] private MoveWithMouse builder;

    // Start is called before the first frame update
    void Start()
    {
        viewInstance.gameObject.SetActive(false);
        _buildMenuConfiguration.BuildMenuConfigurationData.ForEach((data) =>
        {
            var buildMenuTowerButtonView = Instantiate(viewInstance, transform.position, transform.rotation, transform);
            buildMenuTowerButtonView.gameObject.SetActive(true);
            buildMenuTowerButtonView.SetData(data, () => onBuildClicked(data.TowerPrefab, data.Price));
        });
    }

    private void onBuildClicked(GameObject dataTowerPrefab, int dataPrice)
    {
        var gameObject = Instantiate(dataTowerPrefab, new Vector3(0,0,0), Quaternion.identity);
        
        builder.SetTowerPrefab(gameObject);
    }
}
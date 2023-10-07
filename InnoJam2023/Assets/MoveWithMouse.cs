using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Towers;
using Unity.VisualScripting;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    public GameObject TowerPrefab;

    private Color currentColor = Color.blue;

    private float currentPrice;

    private DrugManager drugManager;
    
    

    public void SetTowerPrefab(GameObject TowerPrefab, float price)
    {
        this.TowerPrefab = TowerPrefab;
        this.TowerPrefab.transform.parent = gameObject.transform;
        this.TowerPrefab.transform.position = gameObject.transform.position;
        this.TowerPrefab.gameObject.layer = 2;
        currentPrice = price;
        drugManager = FindObjectOfType<DrugManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (TowerPrefab == null)
        {
            return;
       }
        //Create a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //If the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.transform.gameObject.CompareTag("Map")
                && !hit.transform.gameObject.CompareTag("Tower")
                && !hit.transform.gameObject.CompareTag("Way")) return;
            
            transform.position = hit.point;
            
            var hits = Physics.OverlapBox( transform.position, new Vector3(1f, 1f, 1f), Quaternion.identity);
            var color = Color.green;
            if (hits
                .Where(hit => hit.gameObject != TowerPrefab)
                .Any(hit => !hit.transform.gameObject.CompareTag("Map")))
            {
                color = Color.red;
            }

            if (color != currentColor)
            {
                SetAllSubMaterialsColor(color);
                currentColor = color;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cancel();
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            drugManager.decreaseDrugs(currentPrice);
            ConstructBuilding();
        }
    }

    private void Cancel()
    {
        Destroy(TowerPrefab);
    }

    private void ConstructBuilding()
    {
        if (currentColor != Color.green)
        {
            return;
        }
        
        SetAllSubMaterialsColor(Color.white);
        
        TowerPrefab.transform.parent = null;
        TowerPrefab.gameObject.layer = 0;
        
        TowerPrefab.GetComponent<TowerManager>().Construct(1);
    }

    private void SetAllSubMaterialsColor(Color color)
    {
        foreach (var componentsInChild in GetComponentsInChildren<MeshRenderer>())
        {

            componentsInChild.material.color = color;
        }
    }
}

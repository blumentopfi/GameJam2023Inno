using System.Collections;
using System.Collections.Generic;
using Towers;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private GameObject lastClicked;
    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            //Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //If the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == lastClicked)
                {
                    return;
                }

                if (lastClicked != null)
                {
                    lastClicked.SendMessage("OnDeselected");
                    lastClicked = null;
                }

                //If the object hit is a tower
                if (hit.transform.gameObject.tag == "Tower")
                {
                    //Get the tower component
                    hit.transform.gameObject.SendMessage("OnSelected");
                    lastClicked = hit.transform.gameObject;
                }

            }
            else
            {
                if (lastClicked != null)
                {
                    lastClicked.SendMessage("OnDeselected");
                    lastClicked = null;
                }
            }
        }
    }
}

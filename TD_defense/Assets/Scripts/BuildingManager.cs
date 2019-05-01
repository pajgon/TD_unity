using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{   
    public GameObject [] buildings;
    private BuildingPlacement buildingPlacement;



    private void Start()
    {
        buildingPlacement = GetComponent<BuildingPlacement>();
    }



    public void Name()
    {
        buildingPlacement.SetItem(buildings[0]);
    }

     
        
    }

        


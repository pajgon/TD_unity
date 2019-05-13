using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SellandUpgrade : MonoBehaviour
{

    GameObject[] TowersType;
    GameObject[] Towers;




    public BuildBuilding build;
    public UI ui;


    private float CurrentLevel;
    private string TowerType;



    void Start()
    {
        build = GetComponent<BuildBuilding>();
        ui = GetComponent<UI>();

        //nacte veze ve slozkach
        Towers = Resources.LoadAll<GameObject>("Towers");





    }

    public void Upgrade()
    {
        CurrentLevel = build.Tower.GetComponent<Tower>().level;
        TowerType = build.Tower.GetComponent<Tower>().TowerType;





        foreach (GameObject TowerModel in Towers)
        {

            if (TowerType.Equals(TowerModel.GetComponent<Tower>().TowerType) && CurrentLevel + 1 == TowerModel.GetComponent<Tower>().level)
            {


             
                ui.buildTower(TowerModel, build.Tower.GetComponent<Transform>().position, ui.UpgradeNode, build.Tower, build.TowerCanvasclicked);
              

            }

        }

    }

    public void Sell()
    {
        ui.Money += build.Tower.GetComponent<Tower>().Sell;

        Debug.Log(build.Tower.GetComponent<Tower>().PlanePlace);
        build.Tower.GetComponent<Tower>().PlanePlace.SetActive(true);

        Destroy(build.Tower);




    }
}
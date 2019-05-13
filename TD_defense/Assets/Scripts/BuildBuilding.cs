using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BuildBuilding : MonoBehaviour
{

    UI ui;

    public float PosX;
    public float PosY;
    public float PosZ;

    public bool PlaneCanvasclicked = false;
    public bool TowerCanvasclicked = false;



    public GameObject plane;
    public GameObject Tower;

    public Vector3 TowerPosition;
    public Vector3 PlanePosition;

    private Sprite Max;
    private Sprite UpgradeSprite;



    public void Start()
    {
        UpgradeSprite = Resources.Load<Sprite>("Sprites/UpgradeButton2") as Sprite;
        Max = Resources.Load<Sprite>("Sprites/SellButton2") as Sprite;
        GameObject camera = new GameObject();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        ui = camera.GetComponent<UI>();


    }

    IEnumerator Delay(bool canvasclicked, GameObject panel)
    {

        yield return new WaitForSeconds(0.2f);
        if (canvasclicked)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }

    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhinfo;

            float raylenght = Mathf.Infinity;
            bool didHit = Physics.Raycast(toMouse, out rhinfo, raylenght);


            if (didHit)
            {
                if (rhinfo.collider.gameObject.tag == "Tower")
                {
                    Tower = rhinfo.collider.gameObject;


                    TowerPosition = Tower.GetComponent<Tower>().firepoint.position;


                    if (Tower.GetComponent<Tower>().level > 2)
                    {

                        TowerPosition.y += 4f;


                         
                            

                        ui.UpgradeNode.transform.position = TowerPosition;

                        TowerPosition.y -= 4f;
                        ui.UpgradeNode.SetActive(true);

                        TowerCanvasclicked = true;
                    }


                    else
                    {

                        TowerPosition.y += 2.5f;

                       

                        ui.UpgradeNode.transform.position = TowerPosition;

                        TowerPosition.y -= 2.5f;
                        ui.UpgradeNode.SetActive(true);

                        TowerCanvasclicked = true;
                    }



                }
                else
                {
                    TowerCanvasclicked = false;
                    StartCoroutine(Delay(TowerCanvasclicked, ui.UpgradeNode));

                }



                if (rhinfo.collider.name == "Plane")
                {
                    plane = rhinfo.collider.gameObject;

                    PlanePosition = plane.transform.position;
                    PlanePosition.y += 2f;

                    ui.BuildNode.transform.position = PlanePosition;

                    PlanePosition.y -= 2f;
                    ui.BuildNode.SetActive(true);

                    PlaneCanvasclicked = true;


                }
                else
                {
                    PlaneCanvasclicked = false;
                    StartCoroutine(Delay(PlaneCanvasclicked, ui.BuildNode));

                }






            }


        }
    }

}











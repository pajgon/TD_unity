using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildBuilding : MonoBehaviour
{
    Build build = new Build();
    UI ui;

    public float PosX;
    public float PosY;
    public float PosZ;
    
   
    
    public GameObject plane;

    public void Start()
    {
        GameObject camera = new GameObject();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        ui = camera.GetComponent<UI>();

    
    }

    



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhinfo;
            bool didHit = Physics.Raycast(toMouse, out rhinfo);

            if (didHit)
            {
                if (rhinfo.transform.name == "BuildTowerText")
                {
                    Debug.Log("Trefa");
                }

                if (rhinfo.collider.name == "Plane")
                {
                     plane = rhinfo.collider.gameObject;
                     PosX = plane.transform.position.x;
                     PosY = plane.transform.position.y;
                     PosZ = plane.transform.position.z;

                    ui.BuildNode.transform.position = new Vector3(PosX, PosY, PosZ);
                    ui.BuildNode.SetActive(true);


                                      
                }
                else
                {
                    
                }
                Debug.Log(rhinfo.transform.name + "  " + rhinfo.point);
            }
            else
            {
                Debug.Log("emptyspace");
            }

        }
    }

}










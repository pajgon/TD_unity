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
    
    public Color rayColor = Color.white;
    GameObject tower;
    public GameObject plane;

    public void Start()
    {
        GameObject camera = new GameObject();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        ui = camera.GetComponent<UI>();

        





         tower = (Resources.Load("War_Tower")) as GameObject;
        if (tower != null)
        {
            Debug.Log("je to tam");
        }

        else
        {
            Debug.Log("nope neni to tam");
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
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


                   // build.build(tower, PosX, PosY, PosZ);
                   
                   // rhinfo.collider.gameObject.SetActive(false);
                    
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










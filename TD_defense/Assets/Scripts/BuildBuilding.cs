using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{

    public Color rayColor = Color.white;



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
            bool didHit = Physics.Raycast(toMouse, out rhinfo, 500.0f);

            if (didHit)
            {
                if (rhinfo.collider.name == "Plane")
                {
                    rhinfo.collider.gameObject.SetActive(false);
                }
                Debug.Log(rhinfo.collider.name + "  " + rhinfo.point);
            }
            else
            {
                Debug.Log("emptyspace");
            }

        }
    }

}










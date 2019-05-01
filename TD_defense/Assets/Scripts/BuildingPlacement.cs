using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{

    private Transform currentBuilding;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBuilding != null)
        {
            Vector3 v3 = Input.mousePosition;
            v3 = new Vector3(v3.x, v3.y, transform.position.y);
            Vector3 p = Camera.main.ScreenToWorldPoint(v3);
            currentBuilding.position = new Vector3(p.x, 0, p.z);
        }
    }
    public void SetItem(GameObject gm)
    {
        currentBuilding = ((GameObject)Instantiate(gm)).transform;
    }
}

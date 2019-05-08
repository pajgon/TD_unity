using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour

{

    

    public void buildWar_tower(GameObject prefab ,float PosX, float PosY, float PosZ)
    {
        
        Instantiate(prefab, new Vector3 (PosX, 0.5f + PosY, PosZ) , Quaternion.Euler(-90,0,0));     

    }

    private void Start()
    {

        GameObject tower = (Resources.Load("War_Tower")) as GameObject;
}

    void Update()
    {

        
    }
}

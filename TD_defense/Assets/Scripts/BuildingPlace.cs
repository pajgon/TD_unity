using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    public GameObject Place;
    private double ScaleX = 0.1;
    private double ScaleY = 0.1;
    private double ScaleZ = 0.1;


    public Color rayColor = Color.white;
    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawCube(gameObject.transform.position, new Vector3(1, 0.1f, 1));
    }


        void Start()
    {

        
        GameObject prefab = (Resources.Load("Plane")) as GameObject;

        
        Place = this.gameObject;
        Place.name = "Plane";


       
        Place.AddComponent<MeshCollider>();
        Place.AddComponent<MeshRenderer>();
        Place.AddComponent<MeshFilter>();
        
        // nastaveni velikosti stavebni parcely
        Transform transform = Place.GetComponent<Transform>();
        Vector3 scale = new Vector3 (0.1f, 0.1f, 0.1f);
        transform.localScale = scale;

        MeshFilter MeshF = Place.GetComponent<MeshFilter>();
        MeshF.sharedMesh = prefab.GetComponent<MeshFilter>().sharedMesh;




        MeshCollider MeshC = Place.GetComponent<MeshCollider>();
        MeshC.sharedMesh = prefab.GetComponent<MeshFilter>().sharedMesh;


        MeshRenderer MeshR = GetComponent<MeshRenderer>();
        MeshR.sharedMaterial = prefab.GetComponent<MeshRenderer>().sharedMaterial;


    }

    
    void Update()
    {
        
    }
}

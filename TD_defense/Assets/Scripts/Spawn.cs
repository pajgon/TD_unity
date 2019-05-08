using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawn : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>();
    Transform[] arrayPoints;
    GameObject[] arrayObject;


    public float SpawnTime = 0.5f;
    public bool num;
    public int currentUnits = 0;
    public int deathUnits = 0;
    public int maxUnits = 3;
    public float nextWave = 15.0f;

    private GameObject animal;
    



    


    void Start()
    {
        
        animal = Resources.Load("Animal") as GameObject;

        arrayPoints = GetComponentsInChildren<Transform>();

        foreach (Transform path_obj in arrayPoints)
        {    
            if (path_obj != this.transform)
            {
                checkpoints.Add(path_obj);
                

                if (checkpoints.Count == arrayPoints.Length)
                {
                    AddCollider(path_obj.gameObject);

                }

                
            }
        }
        

         InvokeRepeating("SpawnUnit", SpawnTime, SpawnTime);
       
    }
    

    
    void Update()
    {
        
    }

    void SpawnUnit()
    {

        
        

        if (num)
        {
            GameObject m = animal;

           
            int spawnIndex = 0;
            m.name = "Enemy";
            m.tag = "Enemy";
            Instantiate(m, checkpoints[spawnIndex].position, checkpoints[spawnIndex].rotation);
            
            currentUnits++;
            
       

        }

        if (currentUnits > maxUnits - 1)
        {
            num = false;
            
        }

        if (currentUnits <= maxUnits - 1)
        {
            num = true;
        }
    }
    void AddCollider(GameObject obj)
    {
        float scale = 1.3f;
        obj.AddComponent<BoxCollider>();
        BoxCollider collider =  obj.GetComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(scale ,scale , scale);
        Despawn dew = obj.AddComponent<Despawn>();
        Spawn spawn = obj.GetComponentInParent<Spawn>();
        dew.spawn = spawn;
    }
    







}

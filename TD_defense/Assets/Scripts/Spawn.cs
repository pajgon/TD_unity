using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawn : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>();
    Transform[] arrayPoints;
    GameObject[] arrayObject;


    public float SpawnTime = 2f;
    public bool num;
    private int WaveNummber = 1;
    public int PathNummber = 1;
    bool CurrentWave = false;

    private GameObject animal;


    private GameObject Path1;
    private EditorPath Path1Editor;


    private GameObject Path2;
    private EditorPath Path2Editor;


    private GameObject m;
    


    IEnumerator SpawnDelay(GameObject unit, List<Transform> path ,float spawnTime ,float NummberUnits, EditorPath pathToFollow)
    {

        CurrentWave = true;

        for (int i = 0; i < NummberUnits; i++)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnUnits(unit, path, pathToFollow);
        }

        CurrentWave = false;
        WaveNummber++;
    }

    void SpawnUnits(GameObject unit,List<Transform> path, EditorPath pathToFollow)
    {
        unit.name = "Enemy";
        unit.tag = "Enemy";
        unit.GetComponent<MoveOnPath>().PathToFollow = pathToFollow;
        Instantiate(unit, path[0].position, path[0].rotation);
       

    }


    void Start()
    {
        
        animal = Resources.Load("Units/Animal") as GameObject;



        Path1 = Resources.Load("Paths/Path") as GameObject;
        Path1Editor = Path1.GetComponent<EditorPath>();

        Path2 = Resources.Load("Paths/PathRight") as GameObject;
        Path2Editor = Path2.GetComponent<EditorPath>();


        arrayPoints = GetComponentsInChildren<Transform>();
        WaveNummber = 1;

        foreach (Transform path_obj in arrayPoints)
        {    
            if (path_obj != this.transform)
            {
                checkpoints.Add(path_obj);
                

                if (checkpoints.Count == arrayPoints.Length - 1)
                {
                    AddCollider(path_obj.gameObject);

                }

                
            }
        }

        
          
        
        


     
       
    }
    

    
    void Update()
    {

        if (PathNummber == 1)
        {
            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(animal, checkpoints, 1, 5, Path1Editor));
            }

            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(animal, checkpoints, 3, 2, Path1Editor));
            }

        }
        else if (PathNummber == 2)
        {
            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(animal, checkpoints, 3, 2, Path2Editor));
            }

            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(animal, checkpoints, 1, 5, Path2Editor));
            }
        }
       

    }


    void AddCollider(GameObject obj)
    {
        float scale = 1.3f;
        obj.AddComponent<BoxCollider>();
        BoxCollider collider =  obj.GetComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(scale ,scale , scale);
        Spawn spawn = obj.GetComponentInParent<Spawn>();
        
    }
    







}

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

    Despawn dev;

    private GameObject JellikZluta;
    private GameObject JellikCerna;
    private GameObject JellikBila;
    private GameObject golem;


    private GameObject PathLeft1;
    private EditorPath PathLeft1Editor;


    private GameObject PathRight1;
    private EditorPath PathRight1Editor;

    private GameObject PathRight2;
    private EditorPath PathRight2Editor;

    private GameObject PathLeft2;
    private EditorPath PathLeft2Editor;


    private GameObject m;



    IEnumerator SpawnDelay(GameObject unit, List<Transform> path, float spawnTime, float NummberUnits, EditorPath pathToFollow)
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

    void SpawnUnits(GameObject unit, List<Transform> path, EditorPath pathToFollow)
    {
        unit.name = "Enemy";
        unit.tag = "Enemy";
        unit.GetComponent<MoveOnPath>().PathToFollow = pathToFollow;
        Instantiate(unit, path[0].position, path[0].rotation);


    }


    void Start()
    {

        JellikZluta = Resources.Load("Units/JellikZluta") as GameObject;
        JellikCerna = Resources.Load("Units/JellikCerna") as GameObject;
        JellikBila = Resources.Load("Units/JellikBila") as GameObject;
        golem = Resources.Load("Units/Golem") as GameObject;



        PathLeft1 = Resources.Load("Paths/PathLeft1") as GameObject;
        PathLeft1Editor = PathLeft1.GetComponent<EditorPath>();

        PathLeft2 = Resources.Load("Paths/PathLeft2") as GameObject;
        PathLeft2Editor = PathLeft2.GetComponent<EditorPath>();

        PathRight2 = Resources.Load("Paths/PathRight2") as GameObject;
        PathRight2Editor = PathRight2.GetComponent<EditorPath>();

        PathRight1 = Resources.Load("Paths/PathRight1") as GameObject;
        PathRight1Editor = PathRight1.GetComponent<EditorPath>();


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
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 5, 2, PathLeft1Editor));
            }

            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 3, 2, PathLeft1Editor));
            }

        }
        else if (PathNummber == 2)
        {
            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(golem, checkpoints, 3, 2, PathRight1Editor));
            }

            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 1, 5, PathRight1Editor));
            }
        }
        else if (PathNummber == 3)
        {
            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 3, 2, PathRight2Editor));
            }


            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(golem, checkpoints, 1, 5, PathRight2Editor));
            }
        }
        else if (PathNummber == 4)
        {

            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 3, 2, PathLeft2Editor));
            }


            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 1, 5, PathLeft2Editor));
            }

        }


    }


    void AddCollider(GameObject obj)
    {
        float scale = 1.3f;
        obj.AddComponent<BoxCollider>();
        BoxCollider collider = obj.GetComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(scale, scale, scale);
        Spawn spawn = obj.GetComponentInParent<Spawn>();
        obj.AddComponent<Despawn>();

    }








}

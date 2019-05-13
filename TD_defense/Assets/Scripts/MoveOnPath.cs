using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour

   {
    public EditorPath PathToFollow;
    private UI ui;
   


    public int CurrenWayPointID = 0;
    public float speed = 2f;
    public float reachDistance = 1f;
    public float rotationspeed = 5.0f;
    public string pathName;
    public float HP = 50f;
    public float cost = 5;





    Vector3 last_position;
    Vector3 current_position;



  
    void Start()
    {

        GameObject camera = new GameObject();
     camera = GameObject.FindGameObjectWithTag("MainCamera");

       ui = camera.GetComponent<UI>();

        last_position = transform.position;
        


    }

    
    void Update()
    {
        float distance = Vector3.Distance(PathToFollow.path_objs[CurrenWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrenWayPointID].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrenWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationspeed);

        if (distance <= reachDistance)
        {
            CurrenWayPointID++;
        }

       
        if (HP <= 0)
        {
            ui.Money = ui.Money + cost;
            Destroy(this.gameObject);
;        }
    }
    






}

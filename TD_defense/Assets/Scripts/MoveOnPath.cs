using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour

   {
    public EditorPath PathToFollow;
   


    


    public int CurrenWayPointID = 0;
    public float speed = 2f;
    private float reachDistance = 1f;
    public float rotationspeed = 5.0f;
    public string pathName;
    public float HP = 50f;
    
  



    Vector3 last_position;
    Vector3 current_position;



  
    void Start()
    {
        

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

        if (CurrenWayPointID >= PathToFollow.path_objs.Count)
        {

            
            
          //  Destroy(this.gameObject);
            

            
            
        }
        if (HP <= 0)
        {
            Destroy(this.gameObject);
;        }
    }
    






}

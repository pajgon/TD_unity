using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    private Transform target;
    private MoveOnPath HP;
    public Tower tower;
    

    public float speed = 10f;

    public void seek(Transform _target)
    {
        target = _target;
      //  FindObjectOfType<AudioManager>().PlaySound("shotTower");
    }


    void Start()
    {
       
    }

   
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        MoveOnPath HP = target.GetComponent<MoveOnPath>();

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        if (dir.magnitude <= distanceThisFrame)
        {
            HP.HP -= tower.damage;
            HitTarget();          
           
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);



    }


    void HitTarget()
    {
        
        Destroy(gameObject);
        
    }

   
}

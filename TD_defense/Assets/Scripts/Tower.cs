using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target;
    public float damage = 10f;
    public float AttackPerSec = 1f;
    private bool firing = false;
    public float range = 7f;
    public string enemyTag = "Enemy";
    



    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }



    // zamerovani
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = range;
        GameObject nearestEnemy = null;
        

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            if (target == null)
            {
                target = nearestEnemy.transform;
            }

            else if (Vector3.Distance(transform.position, target.transform.position) > range)
            {
                target = nearestEnemy.transform;
            }
            
            
        }
        else
        {
            target = null;
        }

    }


    //akce kazdy per frame
    private void Update()
    {
        if (target == null)
            return;
       else if (firing == false)
        {
            firing = true;
            StartCoroutine(Delay(target));
        }

    }


    // casovac strelby
    IEnumerator Delay(Transform enemy)
    {
        Fire(enemy);
        yield return new WaitForSeconds(1 / AttackPerSec);
        firing = false;


    }




    //graficke zobrazeni range veze v editoru
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // strelba
    private void Fire(Transform enemyGameobject)
    {
        MoveOnPath target = enemyGameobject.GetComponentInParent<MoveOnPath>();
        target.HP -= damage;


    }







}











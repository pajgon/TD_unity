using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower1 : MonoBehaviour
{

    public float damage = 10f;
    public float AttackPerSec = 1f;
    bool firing = false;


    private List<Collider> colliders = new List<Collider>();



    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.GetComponentInParent<MoveOnPath>() != null)
        {
            if (!colliders.Contains(enemy))
            {

                colliders.Add(enemy);

            }

        }

    }
    private void OnTriggerExit(Collider enemy)
    {
        colliders.Remove(enemy);


    }

    private void Fire(Collider collider)
    {
        MoveOnPath target = collider.GetComponentInParent<MoveOnPath>();
        if (target.HP <= damage)
        {
            colliders.Remove(collider);
        }
        target.HP -= damage;


    }

    IEnumerator Delay()
    {
        Fire(colliders[0]);
        yield return new WaitForSeconds(1 / AttackPerSec);
        firing = false;


    }



    void Start()
    {

    }


    void Update()
    {
        if (colliders.Count >= 1 && firing == false)
        {
            firing = true;
            StartCoroutine(Delay());
        }

    }
}

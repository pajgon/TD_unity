using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public float damage = 1f;
    public float AttackPerSec = 2f;


    private List<Collider> colliders = new List<Collider>();
    


    private void OnTriggerEnter(Collider enemy)
    {
        if (!colliders.Contains(enemy))
        {
            colliders.Add(enemy);
           
           
            
        }
    }
    private void OnTriggerExit(Collider enemy)
    {
        colliders.Remove(enemy);
        
    }

    private void fire(Collider collider)
    {
        MoveOnPath target = collider.GetComponentInParent<MoveOnPath>();
        if (target.HP <= damage)
        {
            colliders.Remove(collider);
        }
        target.HP -= damage;
        StartCoroutine(Pause());
    }


    IEnumerator Pause()
    {
        
        yield return new WaitForSeconds(1 / AttackPerSec);
     
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        if (colliders.Count >= 2)
        {
            fire(colliders[1]);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public Spawn spawn;

    private void Start()
    {
        spawn = GetComponentInParent<Spawn>();
    }

    public void OnTriggerEnter(Collider enemy)
    {// MoveOnPath parent = enemy.GetComponent<MoveOnPath>();
        Destroy(enemy.gameObject);
        spawn.currentUnits--;
        
       
    }
    


}

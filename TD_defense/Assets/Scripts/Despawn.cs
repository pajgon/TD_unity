using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{

    private UI ui;
    public Spawn spawn;

    private void Start()
    {
        GameObject camera = new GameObject();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        ui = camera.GetComponent<UI>();

    }

    public void OnTriggerEnter(Collider enemy)
    {
        Destroy(enemy.gameObject);
        ui.Lives--;



    }



}

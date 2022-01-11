using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{

    public bool isWorking;
    private GameObject[] enemies;


    // Update is called once per frame
    void Update()
    {
        if(isWorking)
        {
            enemies = GameObject.FindGameObjectsWithTag("enemy");

            if (enemies.Length == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandom : MonoBehaviour
{

    public GameObject[] spawnees;
    public Transform spawnPos;

    int randomInt;

    public bool startMe;

    public bool dontParent;

    // Start is called before the first frame update
    void Start()
    {
        if(startMe)
        {
            spawn();
        }

    }

    public void spawn()
    {
        randomInt = Random.Range(0, spawnees.Length);
        GameObject room = Instantiate(spawnees[randomInt], spawnPos.position, Quaternion.identity);
        if (dontParent == false)
        {
            room.transform.SetParent(transform);
        }
    }
}

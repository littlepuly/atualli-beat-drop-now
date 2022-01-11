using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{

    public GameObject boom;
    public float destroyTime;


    private void Start()
    {
        destroyTime = 130 / 60;
        Invoke("explode", destroyTime);
    }

    public void explode()
    {
        GameObject currentBoom = Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(currentBoom, destroyTime);
        Destroy(gameObject);
    }
}

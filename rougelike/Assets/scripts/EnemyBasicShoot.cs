using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicShoot : MonoBehaviour
{


    public GameObject bullet;
    public Transform shootPos;

    private GameObject[] bits;

    public float fireRate;
    private float currentFireRate;

    public int Qtime;
    private int currentQtime;

    public Animator anim;

    public GameObject shootParticles;

    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = fireRate;
        currentQtime = Qtime;
    }

    // Update is called once per frame
    void Update()
    {
        bits = GameObject.FindGameObjectsWithTag("bit");

        currentFireRate -= Time.deltaTime;


        if(bits.Length != 0)
        {
            if (currentFireRate <= 0)
            {
                if (currentQtime <= 0)
                {
                    anim.SetTrigger("shoot");
                    Instantiate(bullet, shootPos.position, Quaternion.identity);
                    Instantiate(shootParticles, shootPos.position, shootPos.rotation);
                    currentFireRate = fireRate;
                    currentQtime = Qtime;
                }
                else
                {
                    currentQtime--;
                    currentFireRate = fireRate;
                }
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardEnemy : MonoBehaviour
{
    public GameObject bullet;
    private Transform Player;

    private GameObject[] bits;

    public float fireRate;
    private float currentFireRate;

    public int Qtime;
    private int currentQtime;

    public Animator anim;

    public GameObject shootParticles;

    bool shot;

    GameObject myBullet;

    // Start is called before the first frame update
    void Start()
    {
        currentFireRate = fireRate;
        currentQtime = Qtime;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        bits = GameObject.FindGameObjectsWithTag("bit");

        currentFireRate -= Time.deltaTime;


        if (bits.Length != 0)
        {
            if (currentFireRate <= 0)
            {
                if (currentQtime <= 0)
                {
                    anim.SetTrigger("shoot");
                    currentFireRate = fireRate;
                    currentQtime = Qtime;

                    if (shot == false)
                    {
                        myBullet = Instantiate(bullet, Player.position, Quaternion.identity);
                        Instantiate(shootParticles, Player.position, Quaternion.identity);
                        shot = true;
                    }
                    else if (shot == true)
                    {
                        myBullet.GetComponent<explosion>().explode();
                        shot = false;
                    }
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

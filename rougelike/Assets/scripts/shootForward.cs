using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootForward : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPos;

    private GameObject[] bits;

    public float fireRate;
    private float currentFireRate;

    public int Qtime;
    private int currentQtime;

    public float speed;

    public Animator anim;

    public GameObject particles;

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


        if (bits.Length != 0)
        {
            if (currentFireRate <= 0)
            {
                if (currentQtime <= 0)
                {
                    if (anim != null)
                    {
                        anim.SetTrigger("shoot");
                    }
                    GameObject myBullet = Instantiate(bullet, shootPos.position, shootPos.rotation);
                    myBullet.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
                    Instantiate(particles, shootPos.position, shootPos.rotation);
                    Destroy(myBullet, 4f);
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

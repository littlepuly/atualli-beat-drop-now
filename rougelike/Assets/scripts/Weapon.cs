using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;
    public Transform shotPos;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float offset;

    private GameManager gm;

    private GameObject[] bits;

    public GameObject shootParticles;


    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        bits = GameObject.FindGameObjectsWithTag("bit");

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);



        if(Input.GetMouseButtonDown(0))
        {
            if (timeBtwShots <= 0)
            {
                if (bits.Length != 0) 
                {
                    gm.scoreMult++;
                    Instantiate(bullet, shotPos.position, transform.rotation);
                    Instantiate(shootParticles, shotPos.position, transform.rotation);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    gm.scoreMult = 1;
                }
              
            }
            else
            {
                gm.scoreMult = 1;
            }
            
        }

        timeBtwShots -= Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class alleyBullet : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    private Rigidbody2D rb;

    public int damage;

    public GameObject explodeParticles;

    private Shaker myShaker;
    public ShakePreset shakePreset;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myShaker = Camera.main.GetComponent<Shaker>();
        Invoke("DestroyMe", lifeTime);
        myShaker.Shake(shakePreset);
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = transform.up * speed;
    }

    void DestroyMe()
    {

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("enemy"))
        {
            collision.GetComponent<EnemyBase>().takeDamage(damage);
            Instantiate(explodeParticles, transform.position, Quaternion.identity);
            myShaker.Shake(shakePreset);
            DestroyMe();
        }
        else if(collision.CompareTag("shield"))
        {
            Instantiate(explodeParticles, transform.position, Quaternion.identity);
            myShaker.Shake(shakePreset);
            DestroyMe();
        }
    }
}

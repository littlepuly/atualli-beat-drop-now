using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFollow : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private Transform target;
    Vector2 moveDir;

    public float destroyTime;
    public int damage;

    public float knockbackPower;
    public float KnockbackDuration;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        moveDir = (target.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}

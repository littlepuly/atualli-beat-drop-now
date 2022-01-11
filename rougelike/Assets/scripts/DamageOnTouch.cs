using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{

    public int damage;

    public float knockbackPower;
    public float KnockbackDuration;

    public bool isDestroyed;

    private GameObject target;
    public GameObject hitParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().takeDamage(damage);

           StartCoroutine(collision.GetComponent<PlayerController>().knockBack(KnockbackDuration, knockbackPower, this.transform));
            
            if(isDestroyed)
            {
                Instantiate(hitParticles, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}

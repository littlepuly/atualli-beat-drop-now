using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class EnemyBase : MonoBehaviour
{

    public int MaxHealth;
    private int CurrentHealth;

    private GameManager gm;
    public int scorePlus;

    public GameObject explosionParticles;
    public GameObject myScorePopUp;

    private Shaker myShaker;

    public ShakePreset shakePreset;

    // Start is called before the first frame update
    void Start()
    {
        myShaker = Camera.main.GetComponent<Shaker>();
        CurrentHealth = MaxHealth;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            die();
        }
    }

    public void takeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    void die()
    {
        gm.addScore(scorePlus);
        myShaker.Shake(shakePreset);
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        GameObject score = Instantiate(myScorePopUp, transform.position, Quaternion.identity);
        score.GetComponent<scorePopUp>().changeText((scorePlus * gm.scoreMult).ToString());
        Destroy(gameObject);
    }
}

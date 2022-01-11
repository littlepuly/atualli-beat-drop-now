using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MilkShake;

public class PlayerManager : MonoBehaviour
{

    public int health;
    private int currentHealth;

    public bool isInvonurable;
    public float InvinsTime;
    public float currentInvinsTime;

    public Text healthText;

    private Shaker myShaker;

    public ShakePreset preset;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        myShaker = Camera.main.GetComponent<Shaker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            die();
        }

        if (isInvonurable)
        {
            currentInvinsTime -= Time.deltaTime;
        }
        if (currentInvinsTime <= 0)
        {
            isInvonurable = false;
        }

        healthText.text = currentHealth.ToString();

    }

    public void takeDamage(int damage)
    {
        if (isInvonurable == false)
        {
            currentHealth -= damage;
            myShaker.Shake(preset);
            currentInvinsTime = InvinsTime;
            isInvonurable = true;
        }
    }

    void die()
    {
        GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().lose();
        this.gameObject.SetActive(false);
    }
}

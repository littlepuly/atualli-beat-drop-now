using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitDrop : MonoBehaviour
{

    private GameManager gameManager;
    public float MaxbitTime;
    private float currentBitTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        gameManager.canPerformAction = true;
        currentBitTime = MaxbitTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentBitTime -= Time.deltaTime;
        if (currentBitTime <= 0)
        {
            deleteMe();
        }
    }

    public void deleteMe()
    {
        gameManager.canPerformAction = false;
        Destroy(gameObject);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableOnTrigger : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            door.SetActive(true);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }

   
}

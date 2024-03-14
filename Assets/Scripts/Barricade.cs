using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    private int hits = 0;
    private void OnCollisionEnter2D(Collision2D other)
    {
        hits++;
        if (hits == 1)
        {
            GetComponent<Animator>().SetTrigger("Damaged");
        }

        if (hits == 4)
        {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform shottingOffset;
    public int points;
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    private Vector3 direction;
    private int numberOfEnemies;
    public float speed;

    private void Start()
    {
        direction = Vector3.left;
        numberOfEnemies = 55;
    }

    private void Update()
    {
        // Move Enemies horizontally
        transform.position += direction * Time.deltaTime * speed / numberOfEnemies;
        if (name == "Enemy30(Clone")
        {
            bool [] shoot =
            {
                false, false, false, false, false, false, false, false, true, false, false, false, false, false, false,
                false, false, false, false, false, false, false, false, true, false, false, false, false, false, false
            };
            if (shoot[Random.Range(0, 31)] == true)
            {
                GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
                Debug.Log("Bang!");
    
                Destroy(shot, 3f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log("Ouch!");
            Destroy(collision.gameObject);
            
            GetComponent<Animator>().SetTrigger("Dead");
            numberOfEnemies--;
        }
        else
        {
            transform.position += Vector3.down;
        }

        if (collision.gameObject.name == "LeftBarrier")
        {
            direction = Vector3.right;
        }

        if (collision.gameObject.name == "LeftBarrier")
        {
            direction = Vector3.left;
        }
        
    }

    void Die()
    {
        Debug.Log("Dead");
        OnEnemyDied.Invoke(points);
        Destroy(gameObject);
    }
}

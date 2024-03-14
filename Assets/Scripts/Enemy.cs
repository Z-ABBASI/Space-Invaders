using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // Death
    public AudioSource death;
    public GameObject explosion;
    public int points;
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    
    // Shoot
    public GameObject enemy3;
    public GameObject bullet;
    public float minShootInterval;
    public float maxShootInterval;
    public float shootTimer;
    public Transform shottingOffset;
    public AudioSource shoot;

    private void Start()
    {
        shootTimer = Random.Range(minShootInterval, maxShootInterval);
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            ResetShootTimer();
        }
    }

    private void Shoot()
    {
        if (gameObject == enemy3)
        {
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            shoot.Play();
            Physics.Raycast(transform.position, Vector3.down, 7);
        }
    }

    private void ResetShootTimer()
    {
        shootTimer = Random.Range(minShootInterval, maxShootInterval);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log("Ouch!");
            Destroy(collision.gameObject);
            
            Instantiate(explosion, this.gameObject.transform);
            death.Play();
            Debug.Log("Dead");
            StartCoroutine(delay());
            OnEnemyDied.Invoke(points);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
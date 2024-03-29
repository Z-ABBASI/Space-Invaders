﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public Transform shottingOffset;
  public delegate void PlayerDied();
  public static event PlayerDied OnPlayerDied;
  private Rigidbody2D rb;
  public AudioSource shoot;
  public GameObject explosion;
  public AudioSource death;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");
        shoot.Play();
        GetComponent<Animator>().SetTrigger("Shoot");

        Destroy(shot, 3f);
      }

      // Move Player horizontally
      rb.position += Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime * 4;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.name == "EnemyBullet(Clone)")
      {
        Debug.Log("Ouch!");
        Destroy(other.gameObject);
        
        Instantiate(explosion, this.gameObject.transform);
        death.Play();
        Debug.Log("Dead");
        StartCoroutine(delay());
      }
    }

    IEnumerator delay()
    {
      yield return new WaitForSeconds(1);
      OnPlayerDied.Invoke();
    }
}
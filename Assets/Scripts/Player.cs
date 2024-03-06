using System;
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

        Destroy(shot, 3f);
      }

      // Move Player horizontally
      rb.position += Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime * 4;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.name == "EnemyBullet(Clone)")
      {
        Debug.Log("Ouch!");
        Destroy(collision.gameObject);
            
        GetComponent<Animator>().SetTrigger("Dead");
        Die();
      }
      else
      {
        Debug.Log("Barrier");
      }
    }

    void Die()
    {
      Debug.Log("Dead");
      OnPlayerDied.Invoke();
      Destroy(gameObject);
    }
}

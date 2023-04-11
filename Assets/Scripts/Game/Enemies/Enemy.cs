using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected int attackRate;
    protected int yPos;
    public bool IsDead  { get; private set;}

    public void Init()
    {
      yPos = (int) Math.Floor(transform.position.y);
    }

    void Start()
    {
      IsDead = false;
    }
    void Update()
    {
      if (IsDead) return;
      Translate();
    }

    public virtual void TakeDamage(float amount, int hitBox)
    {
      if (IsDead) return;
      if(yPos != hitBox) return;
      Debug.Log("Enemy took damage");
      LoseHealth(amount);
    }

    //On colission 2d
    void OnCollisionEnter2D(Collision2D collision)
    {
      if (IsDead) return;
      if (collision.gameObject.CompareTag("Tower"))
      {
        Tower tower = collision.gameObject.GetComponent<Tower>();
        tower.TakeDamage(damage, yPos);
      }
    }

    //Lose Health
    protected virtual void LoseHealth(float amount)
    {
      health -= amount;
      if (health > 0) return;
      IsDead = true;
      Die();
    }

    //Die
    protected virtual void Die()
    {
      Debug.Log("Enemy is dead");
      Destroy(gameObject);
    }

    protected virtual void Translate()
    {
      transform.Translate(-transform.right*speed*Time.deltaTime);
    }
}
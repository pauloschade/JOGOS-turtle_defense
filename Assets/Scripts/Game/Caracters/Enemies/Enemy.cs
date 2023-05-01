using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Enemy : Caracter
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected int attackRate;

    [SerializeField] private int reward = 1;
    private Currency currency;
    private Tower target = null;
    [SerializeField] protected GameManager gameManager;

    public override void Start()
    {
      base.Start();
      currency = Currency.GetInstance();
      gameManager = GameManager.GetInstance();
    }

    public void Init()
    {
      SetYPos();
    }
    protected virtual void Update()
    {
      if (IsDead) return;
      if (target != null) return; 
      Translate();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (target != null) return;
      if (collision.gameObject.CompareTag("Tower"))
      {
        target = collision.gameObject.GetComponent<Tower>();
        if (target.YPos == YPos && (target.GetXPos() == GetXPos() - 1 || target.GetXPos() == GetXPos())) {
          StartCoroutine(AttackMotion());
          return;
        }
        target = null;
        return;
      }
      if (collision.gameObject.CompareTag("EOM"))
      {
        //destroy enemy
        Destroy(gameObject);
        gameManager.SetGameOver();
      }
    }

    protected virtual IEnumerator AttackMotion()
    {
      if (target == null) yield break;
      yield return Animate(attackRate);
      Attack();
      StartCoroutine(AttackMotion());
    }

    void Attack()
    {
      target.TakeDamage(damage, YPos);
    }
    protected virtual void Translate()
    {
      transform.Translate(-transform.right*speed*Time.deltaTime);
    }

    protected override void SetYPos()
    {
      YPos = (int) Math.Floor(transform.position.y);
    }

    public override int GetXPos()
    {
      return (int) Math.Floor(transform.position.x);
    }

    protected override void Die()
    {
      base.Die();
      currency.AddFunds(reward);
    }

}
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
    private Tower target = null;

    public void Init()
    {
      SetYPos();
    }
    void Update()
    {
      if (IsDead) return;
      if (target != null) return; 
      Translate();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (IsDead) return;
      if (collision.gameObject.CompareTag("Tower"))
      {
        target = collision.gameObject.GetComponent<Tower>();
        if (target.YPos == YPos) {
          StartCoroutine(AttackMotion());
          return;
        }
        target = null;
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

}
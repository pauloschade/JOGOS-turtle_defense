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
        Debug.Log("Enemy XPos: " + GetXPos() + " Tower XPos: " + target.GetXPos());
        if (target.YPos == YPos && target.GetXPos() == GetXPos() - 1) {
          StartCoroutine(AttackMotion());
          return;
        }
        target = null;
      }
      if (collision.gameObject.CompareTag("EOM"))
      {
        Die();
      }
    }

    protected virtual IEnumerator AttackMotion()
    {
      if (target.IsDead) yield break;
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

}
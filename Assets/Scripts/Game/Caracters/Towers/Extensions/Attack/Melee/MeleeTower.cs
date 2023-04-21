using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MeleeTower : AttackTower
{
  private List<Enemy> _enemyQueue = new List<Enemy>();
  protected override void Attack()
  {
    target.TakeDamage(damage, YPos);
  }

  public override void Update()
  {
    base.Update();
    if (target != null) return;
    if (_enemyQueue.Count > 0)
    {
      target = _enemyQueue[0];
      _enemyQueue.RemoveAt(0);
      StartCoroutine(AttackMotion());
    }
  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Enemy"))
    {
      if(target != null){
        _enemyQueue.Add(collision.gameObject.GetComponent<Enemy>());
        return;
      };
      target = collision.gameObject.GetComponent<Enemy>();
      if (target.YPos == YPos) {
        StartCoroutine(AttackMotion());
        return;
      }
      target = null;
    }
  }
}
using UnityEngine;
using System.Collections;
public class MeleeTower : AttackTower
{
  protected override void Attack()
  {
    target.TakeDamage(damage, YPos);
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if(target != null) return;
    if (collision.gameObject.CompareTag("Enemy"))
    {
      target = collision.gameObject.GetComponent<Enemy>();
      if (target.YPos == YPos) {
        StartCoroutine(AttackMotion());
        return;
      }
      target = null;
    }
  }
}
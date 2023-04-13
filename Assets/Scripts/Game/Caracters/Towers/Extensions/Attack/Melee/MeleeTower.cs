using UnityEngine;
using System.Collections;
public class MeleeTower : AttackTower
{

  private Enemy target;
  protected override void Attack()
  {
    target.TakeDamage(damage, YPos);
  }

  protected override IEnumerator AttackMotion() {
    if (target.IsDead) yield break;
    yield return base.AttackMotion();
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Collision");
    if(target != null) return;
    Debug.Log("Getting target");
    if (collision.gameObject.CompareTag("Enemy"))
    {
      Debug.Log("Target Set");
      target = collision.gameObject.GetComponent<Enemy>();
      if (target.YPos == YPos) {
        Debug.Log("attacking");
        StartCoroutine(AttackMotion());
        return;
      }
      Debug.Log("Target Null");
      target = null;
    }
  }
}
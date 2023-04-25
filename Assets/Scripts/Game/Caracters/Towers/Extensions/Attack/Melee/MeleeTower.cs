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
    CheckAttack(collision.gameObject);
  }
}
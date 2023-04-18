using UnityEngine;
using System.Collections;
public abstract class AttackTower : Tower
{
  protected Enemy target;
  [SerializeField] protected int damage;
  [SerializeField] protected float attackRate;
  protected virtual IEnumerator AttackMotion()
  {
    if (target.IsDead) yield break;
    yield return Animate(attackRate);
    Attack();
    StartCoroutine(AttackMotion());
  }
  protected abstract void Attack();

}
using UnityEngine;
using System.Collections;
public abstract class AttackTower : Tower
{
  [SerializeField] protected int damage;
  [SerializeField] protected float attackRate;
  protected virtual IEnumerator AttackMotion()
  {
    yield return Animate(attackRate);
    Attack();
    StartCoroutine(AttackMotion());
  }
  protected abstract void Attack();

}
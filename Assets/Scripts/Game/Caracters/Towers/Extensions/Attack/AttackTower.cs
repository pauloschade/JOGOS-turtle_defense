using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public abstract class AttackTower : Tower
{
  protected Enemy target;
  protected List<Enemy> _enemyQueue = new List<Enemy>();
  [SerializeField] protected int damage;
  [SerializeField] protected float attackRate;
  [SerializeField] protected bool IsAttacking = false;

  public override void Update()
  {
    base.Update();
    if (target != null) return;
    if (_enemyQueue.Count > 0)
    {
      target = _enemyQueue[0];
      _enemyQueue.RemoveAt(0);
      if (IsAttacking) return;
      if (target == null) return;
      IsAttacking = true;
      StartCoroutine(AttackMotion());
    }
  }
  protected virtual IEnumerator AttackMotion()
  {
    if (target == null) {
      IsAttacking = false;
      yield break;
    }
    yield return Animate(attackRate);
    Attack();
    StartCoroutine(AttackMotion());
  }

  protected void CheckAttack(GameObject obj)
  {
    if (obj.gameObject.CompareTag("Enemy"))
    {
      if(target != null)
      {
        _enemyQueue.Add(obj.GetComponent<Enemy>());
        return;
      };
      target = obj.GetComponent<Enemy>();
      if (target.YPos == YPos) 
      {
        IsAttacking = true;
        StartCoroutine(AttackMotion());
        return;
      }
      target = null;
    }
  }
  protected abstract void Attack();

}
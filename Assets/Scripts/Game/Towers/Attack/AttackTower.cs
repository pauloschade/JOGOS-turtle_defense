using UnityEngine;
using System.Collections;
public abstract class AttackTower : Tower
{
  [SerializeField] protected int damage;
  [SerializeField] protected float range;
  [SerializeField] protected float attackRate;

  public override void Start()
  {
    base.Start();
    StartCoroutine(AttackDelay());
  }

  protected virtual IEnumerator AttackDelay()
  {
      yield return new WaitForSeconds(1/attackRate);
      Animate();
      Attack();
      StartCoroutine(AttackDelay());
  }
  abstract protected void Attack();

  abstract protected void Animate();

}
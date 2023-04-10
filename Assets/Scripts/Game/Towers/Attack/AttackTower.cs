using UnityEngine;
using System.Collections;
public class AttackTower : Tower
{
  [SerializeField] protected int damage;
  [SerializeField] protected float range;
  [SerializeField] protected float attackRate;
  [SerializeField] protected Sprite[] spriteArray;

  public override void Start()
  {
    base.Start();
    StartCoroutine(AttackMotion());
  }

  protected virtual IEnumerator AttackMotion()
  {
      //return Animate();
      if (isDead) yield break;
      yield return Animate();
      Attack();
      StartCoroutine(AttackMotion());
  }
  protected virtual void Attack() {
    return;
  }

  protected virtual IEnumerator Animate() {
    for (int i = 0; i < spriteArray.Length; i++) {
      gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[i];
      yield return new WaitForSeconds(1/attackRate/spriteArray.Length);
    }
  }

}
using UnityEngine;
using System.Collections;
public class ShooterTower : AttackTower
{
  [SerializeField] protected float speed;
  [SerializeField] protected float range;
  [SerializeField] protected GameObject projectilePrefab; 

  public override void Start()
  {
    base.Start();
    StartCoroutine(AttackMotion());
  }
  protected override void Attack()
  {
    GameObject projectile = Instantiate(projectilePrefab, transform);
    projectile.GetComponent<Projectile>().Init(damage, speed, range, YPos);
  }

}
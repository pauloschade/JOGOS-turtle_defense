using UnityEngine;
using System.Collections;
public class ShooterTower : AttackTower
{
  [SerializeField] protected float speed;
  [SerializeField] protected GameObject projectilePrefab; 

  protected override void Attack()
  {
    GameObject projectile = Instantiate(projectilePrefab, transform);
    projectile.GetComponent<Projectile>().Init(damage, speed, range);
  }

}
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
    SetTriggerCollider();
  }
  protected override void Attack()
  {
    GameObject projectile = Instantiate(projectilePrefab, transform);
    projectile.GetComponent<Projectile>().Init(damage, speed, range, YPos);
  }

  //on collision trigger
  protected void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Enemy")
    {
      target = other.gameObject.GetComponent<Enemy>();
      if (target.YPos == YPos)
      {
        StartCoroutine(AttackMotion());
      }
    }
  }

  protected void SetTriggerCollider()
  {
    //get capsule collider
    CapsuleCollider2D capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
    // BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
    var offset = capsuleCollider.offset;
    var size = capsuleCollider.size;
    offset.x = range / 2;
    size.x = range + 0.5f;
    capsuleCollider.offset = offset;
    capsuleCollider.size = size;
  }

}
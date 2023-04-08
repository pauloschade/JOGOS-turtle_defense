using UnityEngine;
using System.Collections;
public class ShooterTower : Tower
{
  [SerializeField] private float range;
  [SerializeField] private float fireRate;
  [SerializeField] private GameObject bulletPrefab;


  public override void Start()
  {
    base.Start();
    StartCoroutine(ShootDelay());
  }

  IEnumerator ShootDelay()
  {
      yield return new WaitForSeconds(1/fireRate);
      Shoot();
      StartCoroutine(ShootDelay());
  }
  public void Shoot()
  {
    GameObject shotItem = Instantiate(bulletPrefab,transform);
  }

}
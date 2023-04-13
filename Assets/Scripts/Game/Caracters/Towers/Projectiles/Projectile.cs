using UnityEngine;

public abstract class Projectile : MonoBehaviour 
{
    protected int damage;
    protected float speed;
    protected float range;
    protected int yPos;
    protected float distanceTraveled = 0.0f;

    protected virtual void FixedUpdate()
    {
      CheckDistance();
      Translate();
    }

    public virtual void Init(int damage, float speed, float range, int yPos)
    {
      this.damage = damage;
      this.speed = speed;
      this.range = range;
      this.yPos = yPos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Enemy"))
      {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        enemy.TakeDamage(damage, yPos);
        Destroy(gameObject);
      }
    }

    protected virtual void Translate() 
    {
      transform.Translate(transform.right * speed * Time.deltaTime);
      distanceTraveled += speed * Time.deltaTime;
    }

    protected virtual void CheckDistance()
    {
        if (distanceTraveled >= range)
        {
            Destroy(gameObject);
        }
    }
}
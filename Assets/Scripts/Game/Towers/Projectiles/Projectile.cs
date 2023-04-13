using UnityEngine;

public abstract class Projectile : MonoBehaviour 
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float range;
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
        Debug.Log("Projectile collided with enemy");
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        enemy.TakeDamage(damage, yPos);
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
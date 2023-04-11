using UnityEngine;

public abstract class Projectile : MonoBehaviour 
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float range;
    protected float distanceTraveled = 0.0f;

    protected virtual void FixedUpdate()
    {
      CheckDistance();
      Translate();
    }

    public virtual void Init(int damage, float speed, float range)
    {
      this.damage = damage;
      this.speed = speed;
      this.range = range;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            Debug.Log("Shot the enemy");
            //collision.GetComponent<Enemy>().LoseHealth();
            Destroy(gameObject);
        }
        // if (collision.tag == "Out")
        // {            
        //     Destroy(gameObject);
        // }
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
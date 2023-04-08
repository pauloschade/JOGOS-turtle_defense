using UnityEngine;

public class Projectile : MonoBehaviour 
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    //[SerializeField] private GameObject target;
    // public void Init(GameObject target)
    // {
    //   this.target = target;
    // }

    protected virtual void FixedUpdate()
    {
      Translate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            Debug.Log("Shot the enemy");
            //collision.GetComponent<Enemy>().LoseHealth();
            Destroy(gameObject);
        }
        if (collision.tag == "Out")
        {            
            Destroy(gameObject);
        }
    }

    protected virtual void Translate() 
    {
      transform.Translate(transform.right * speed * Time.deltaTime);
      //distanceTraveled += speed * Time.deltaTime;
    }

    // private void CheckDistance()
    // {
    //     if (distanceTraveled >= range)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
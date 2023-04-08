using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public int health;
    public int cost;
    protected Vector3Int cellPosition;
    
    public virtual void Start()
    {
        Debug.Log("Tower is alive");
    }
    public virtual void Init(Vector3Int cellPosition)
    {
        cellPosition = cellPosition;
    }

    //Lose Health
    public virtual bool LoseHealth(int amount)
    {
        //health = health - amount
        health -= amount;

        if (health <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    //Die
    protected virtual void Die()
    {
        Debug.Log("Tower is dead");
        //FindObjectOfType<Spawner>().RevertCellState(cellPosition);
        Destroy(gameObject);
    }

    protected virtual void Spawn()
    {
        
    }
}
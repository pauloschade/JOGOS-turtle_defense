using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected int cost;
    [SerializeField] protected Healthbar healthbar;
    public bool IsDead  { get; private set;}
    protected Vector3Int[] cellPositions;
    
    public virtual void Start()
    {
        //instantiates healthbar
        healthbar = Instantiate(healthbar, transform);
        healthbar.Init(health);
    }

    public virtual void Update()
    {
        if (IsDead) return;
        LoseHealth(0.01f);
    }
    public virtual void Init(Vector3Int[] cellPositions, Tilemap spawnTiles)
    {
        this.cellPositions = cellPositions;
        CenterOnCells(spawnTiles);
        Live();
    }

    public virtual void TakeDamage(float amount, int hitBox)
    {
        if (IsDead) return;
        if(GetHitBoxY() != hitBox) return;
        LoseHealth(amount);
    }

    //Lose Health
    protected virtual void LoseHealth(float amount)
    {
        health -= amount;
        healthbar.SetHealth(health);
        if (health > 0) return;
        IsDead = true;
        Die();
    }
    protected virtual int GetHitBoxY()
    {
        return cellPositions[^1].y;
    }
    //Die
    protected virtual void Die()
    {
        Debug.Log("Tower is dead");
        FindObjectOfType<Spawner>().RevertCellState(cellPositions);
        Destroy(gameObject);
    }

    protected virtual void Live()
    {
        FindObjectOfType<Spawner>().SetCellState(cellPositions);
    }

    protected virtual void CenterOnCells(Tilemap spawnTiles)
    {
        Vector3 center = Vector3.zero;
        float towerSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.y/3;
        foreach (Vector3Int cellPosition in cellPositions)
        {
            center += spawnTiles.GetCellCenterWorld(cellPosition);
        }
        center /= cellPositions.Length;
        transform.position = center + new Vector3(0, towerSize, 0);
    }
}
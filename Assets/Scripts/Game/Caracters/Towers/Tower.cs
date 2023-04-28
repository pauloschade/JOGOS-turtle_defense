using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public abstract class Tower : Caracter
{
    [SerializeField] protected Healthbar healthbar;
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
        SetYPos();
    }
    protected override void LoseHealth(float amount)
    {
        base.LoseHealth(amount);
        healthbar.SetHealth(health);
    }

    protected virtual void Live()
    {
        FindObjectOfType<Spawner>().SetCellState(cellPositions);
    }

    protected override void Die()
    {
        FindObjectOfType<Spawner>().RevertCellState(cellPositions);
        base.Die();
    }

    protected virtual void CenterOnCells(Tilemap spawnTiles)
    {
        Vector3 center = Vector3.zero;
        float towerSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.y/5;
        foreach (Vector3Int cellPosition in cellPositions)
        {
            center += spawnTiles.GetCellCenterWorld(cellPosition);
        }
        center /= cellPositions.Length;
        transform.position = center + new Vector3(0, towerSize, 0);
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //   //Debug.Log("TOWER collision: " + collision.gameObject.name);
    //   return;
    // }

    protected override void SetYPos()
    {
        YPos = cellPositions[^1].y;
    }

    public override int GetXPos()
    {
        return cellPositions[^1].x;
    }
}
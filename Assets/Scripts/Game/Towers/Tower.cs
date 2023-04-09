using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public abstract class Tower : MonoBehaviour
{
    public int health;
    public int cost;
    protected Vector3Int[] cellPositions;
    
    public virtual void Start()
    {
        
    }
    public virtual void Init(Vector3Int[] cellPositions, Tilemap spawnTiles)
    {
        cellPositions = cellPositions;
        CenterOnCells(cellPositions, spawnTiles);
        Live(cellPositions);
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
        FindObjectOfType<Spawner>().RevertCellState(cellPositions);
        Destroy(gameObject);
    }

    protected virtual void Live(Vector3Int[] cellPositions)
    {
        FindObjectOfType<Spawner>().SetCellState(cellPositions);
    }

    protected virtual void CenterOnCells(Vector3Int[] cellPositions, Tilemap spawnTiles)
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
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
  [SerializeField] protected GameObject prefab;
  [SerializeField] protected Transform spawnTowerRoot;
  [SerializeField] protected float towerCost;
  [SerializeField] protected Cost cost;
  protected Currency currency;

  protected virtual void Start()
  {
    currency = Currency.GetInstance();
    cost.Init(towerCost);
  }
  public virtual bool SpawnTower(Vector3Int cellPosition, Tilemap spawnTiles)
  {
    if (currency.balance < towerCost) return false;
    Vector3Int[] cellPositions = GetCellPositions(cellPosition);
    if (!GetCellState(cellPositions, spawnTiles)) return false;
    GameObject tower = Instantiate(prefab, spawnTowerRoot);
    tower.GetComponent<Tower>().Init(cellPositions, spawnTiles);
    Spend(towerCost);
    return true;
  }

  protected virtual Vector3Int[] GetCellPositions(Vector3Int cellPosition)
  {
    return new Vector3Int[] { cellPosition };
  }

  protected bool GetCellState(Vector3Int[] pos, Tilemap spawnTiles)
  {
    foreach(Vector3Int cellPos in pos)
    {
      if (spawnTiles.GetColliderType(cellPos) == Tile.ColliderType.None) return false;
    }
    return true;
  }

  protected void Spend(float amount)
  {
    currency.SpendFunds(amount);
  }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
  [SerializeField] protected GameObject prefab;
  [SerializeField] protected Transform spawnTowerRoot;
  public virtual void SpawnTower(Vector3Int cellPosition, Tilemap spawnTiles)
  {
    Vector3Int[] cellPositions = GetCellPositions(cellPosition);
    if (!GetCellState(cellPositions, spawnTiles)) return;
    GameObject tower = Instantiate(prefab, spawnTowerRoot);
    tower.GetComponent<Tower>().Init(cellPositions, spawnTiles);
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
}
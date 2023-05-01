using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
  [SerializeField] private List<Image> towerUI;
  [SerializeField] private Tilemap spawnTiles;
  [SerializeField] private AudioSource audioSuccess;
  [SerializeField] private AudioSource audioError;
  private int spawnIndex;

  void Start()
  {
    spawnIndex = -1;
    UnhighlightAllTowers();
  }

  void Update()
  {
    if(CanSpawn() && IsMouseClick()) DetectSpawnPoint();
  }

  public void SelectTower(int index)
  {
    spawnIndex = index;
    HighlightTower();
  }

  public void DetectSpawnPoint()
  {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3Int tilePos = spawnTiles.WorldToCell(mousePos);
    Spawn(tilePos);
  }

  void Spawn(Vector3Int tilePos)
  {
    if(towerUI[spawnIndex].GetComponent<TowerSelector>().SpawnTower(tilePos, spawnTiles)) audioSuccess.Play(0);
    else audioError.Play(0);
    UnhighlightTower();
    ClearIndex();
  }
  public void SetCellState(Vector3Int[] pos)
  {
    foreach(Vector3Int cellPos in pos)
    {
      spawnTiles.SetColliderType(cellPos, Tile.ColliderType.None);
    }
  }

  public void RevertCellState(Vector3Int[] pos)
  {
    foreach(Vector3Int cellPos in pos)
    {
      spawnTiles.SetColliderType(cellPos, Tile.ColliderType.Sprite);
    }
  }

  void HighlightTower()
  {
    towerUI[spawnIndex].color = Color.white;
  }

  void UnhighlightTower()
  {
    towerUI[spawnIndex].color = Color.gray;
  }

  void UnhighlightAllTowers()
  {
    for(int i = 0; i < towerUI.Count; i++)
    {
      towerUI[i].color = Color.gray;
    }
  }
  void ClearIndex()
  {
    spawnIndex = -1;
  }

  bool CanSpawn()
  {
    return spawnIndex != -1;
  }

  bool IsMouseClick()
  {
    return Input.GetMouseButtonDown(0);
  }

  
}
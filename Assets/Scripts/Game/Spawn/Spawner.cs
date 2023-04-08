using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
  [SerializeField] private List<Image> towerUI;
  [SerializeField] private Tilemap spawnTiles;
  private int spawnIndex;

  void Start()
  {
    Debug.Log("Start");
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
    Debug.Log("Selected tower");
    HighlightTower();
  }
	
  public void RevertCellState(Vector3Int pos)
  {
    spawnTiles.SetColliderType(pos, Tile.ColliderType.Sprite);
  }

  void DetectSpawnPoint()
  {
    //get the mouse position
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //get the tile position
    Vector3Int tilePos = spawnTiles.WorldToCell(mousePos);
    //get center of tile
    Vector3 tileCenter = spawnTiles.GetCellCenterWorld(tilePos);
    Spawn(tileCenter, tilePos);

  }

  void Spawn(Vector3 tileCenter, Vector3Int tilePos)
  {
    if(spawnTiles.GetColliderType(tilePos) == Tile.ColliderType.Sprite)
    {
      Debug.Log("Spawn");
      towerUI[spawnIndex].GetComponent<TowerSelector>().SpawnTower(tileCenter);
      spawnTiles.SetColliderType(tilePos, Tile.ColliderType.None);
    }
    UnhighlightTower();
    ClearIndex();
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
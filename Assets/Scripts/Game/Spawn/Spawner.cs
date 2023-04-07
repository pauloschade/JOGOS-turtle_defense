using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
  //list of towers (prefabs) to spawn
  public GameObject[] towers;
  //list of towers UI
  public List<Image> towerUI;
  //list of spawn points
  public Tilemap spawnPoints;
  //time between spawns

  public Transform spawnTowerRoot;

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

  void DetectSpawnPoint()
  {
    //get the mouse position
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //get the tile position
    Vector3Int tilePos = spawnPoints.WorldToCell(mousePos);
    //get center of tile
    Vector3 tileCenter = spawnPoints.GetCellCenterWorld(tilePos);
    Spawn(tileCenter, tilePos);

  }

  void Spawn(Vector3 tileCenter, Vector3Int tilePos)
  {
    if(spawnPoints.GetColliderType(tilePos) == Tile.ColliderType.Sprite)
    {
      Debug.Log("Spawn");
      SpawnTower(tileCenter);
    }
    UnhighlightTower();
    ClearIndex();
  }

  void SpawnTower(Vector3 tileCenter) 
  {
    GameObject tower = Instantiate(towers[spawnIndex], spawnTowerRoot);
    tower.transform.position = tileCenter;
    //align with image botton
    tower.transform.position += new Vector3(0, 0.5f, 0);
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
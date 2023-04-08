using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TowerSelector : MonoBehaviour
{
  [SerializeField] private GameObject prefab;
  [SerializeField] private Transform spawnTowerRoot;
  public void SpawnTower(Vector3 tileCenter) 
  {
    GameObject tower = Instantiate(prefab, spawnTowerRoot);
    tower.transform.position = tileCenter;
    float towerSize = tower.GetComponent<SpriteRenderer>().bounds.size.y/3;
    tower.transform.position += new Vector3(0, towerSize, 0);
  }
}
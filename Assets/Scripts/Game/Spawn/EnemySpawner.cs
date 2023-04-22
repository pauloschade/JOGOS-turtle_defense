using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private float spawnInterval=2f;
    [SerializeField] private int totalEnemies= 10;
    [SerializeField] private GameManager gameManager;

    
    public void Start()
    {
      gameManager = GameManager.GetInstance();
      StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
      if(Check()){
        gameManager.SetVictory();
        yield break;
      } 
      SpawnEnemy();
      yield return new WaitForSeconds(spawnInterval);
      StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
      int prefab = Random.Range(0,prefabs.Count);
      int spawnPoint = Random.Range(0,spawnPoints.Count);
      GameObject enemy = Instantiate(prefabs[prefab], spawnPoints[spawnPoint]);
      enemy.GetComponent<Enemy>().Init();
      float towerSize = enemy.GetComponent<SpriteRenderer>().bounds.size.y/3;
      enemy.transform.position += towerSize * Vector3.up;
      totalEnemies --;
    }

    private bool Check()
    {
      return totalEnemies > 0 ? false : true;
    }
}
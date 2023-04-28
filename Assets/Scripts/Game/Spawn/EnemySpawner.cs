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
    private List<GameObject> _enemiesAlive = new List<GameObject>();

    
    public void Start()
    {
      gameManager = GameManager.GetInstance();
      StartCoroutine(SpawnDelay());
    }

    void Update()
    {
      if(gameManager.GameOver || gameManager.Victory) return;
      if(totalEnemies <= 0 && _enemiesAlive.Count == 0) gameManager.SetVictory();
      RemoveDead();
    }

    IEnumerator SpawnDelay()
    {
      if(Check()){
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
      //float towerSize = enemy.GetComponent<SpriteRenderer>().bounds.size.y;
      //enemy.transform.position += towerSize * Vector3.up;
      _enemiesAlive.Add(enemy);
      totalEnemies --;
    }

    private bool Check()
    {
      return totalEnemies > 0 ? false : true;
    }

    private void RemoveDead()
    {
      for(int i = 0; i < _enemiesAlive.Count; i++) {
        if(_enemiesAlive[i] == null){
          _enemiesAlive.RemoveAt(i);
        }
      }
    }
}
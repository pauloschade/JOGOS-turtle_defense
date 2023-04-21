using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Transform> spawnPoints;
    public float spawnInterval=2f;
    public void Start()
    {
      StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
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
    }

}
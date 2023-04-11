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
      Debug.Log("Spawning enemy: " + spawnPoints[spawnPoint].position);
      Instantiate(prefabs[prefab], spawnPoints[spawnPoint]);
    }

}
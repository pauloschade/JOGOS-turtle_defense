using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
  //list of towers (prefabs) to spawn
  public GameObject[] towers;
  //list of spawn points
  public Transform[] spawnPoints;
  //time between spawns
  public float spawnTime = 1f;
  //time to start spawning
  public float spawnDelay = 1f;

  
}
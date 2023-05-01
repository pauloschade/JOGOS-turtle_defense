using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour 
{
  [SerializeField] private GameObject prefab;
  [SerializeField] private GameObject prefabParent;

  private GameManager _gameManager;
  private int currentHearts = 0;

  void Start()
  {
    _gameManager = GameManager.GetInstance();
  }
  
  void Update()
  {
    SetHearts();
  }

  private void SetHearts()
  {
    if(_gameManager.MaxEnemiesCount != currentHearts)
    {
      Debug.Log("SetHearts " + _gameManager.MaxEnemiesCount + " " + currentHearts);
      currentHearts = _gameManager.MaxEnemiesCount;
      DestroyHearts();
      for(int i = 0; i <= currentHearts; i++)
      {
        GameObject heart = Instantiate(prefab, prefabParent.transform);
      }
    }
  }

  private void DestroyHearts()
  {
    foreach(Transform child in prefabParent.transform)
    {
      Destroy(child.gameObject);
    }
  }


}
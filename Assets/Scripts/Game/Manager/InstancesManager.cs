using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InstancesManager : MonoBehaviour
{
  private static GameManager _gameManager;
  private static Currency _currency;
  public int maxEnemiesCount;

  void Start()
  {
    _gameManager = GameManager.GetInstance();
    _gameManager.SetEnemiesCount(maxEnemiesCount);

    _currency = Currency.GetInstance();
  }
  public void Destroy()
  {
    _gameManager.Destroy();
    _currency.Destroy();
  }
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InstancesManager : MonoBehaviour
{
  private static GameManager _gameManager;
  private static Currency _currency;
  [SerializeField] private int _maxEnemiesCount;

  void Start()
  {
    _gameManager = GameManager.GetInstance();
    _gameManager.SetEnemiesCount(_maxEnemiesCount);

    _currency = Currency.GetInstance();
  }
  public void Destroy()
  {
    _gameManager.Destroy();
    _currency.Destroy();
  }
    
}
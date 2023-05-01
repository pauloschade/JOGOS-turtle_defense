using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public sealed class OnEndGame : MonoBehaviour
{
  private InstancesManager _instancesManager;
  private Currency _currency;
  private Levels _levels;

  void Start()
  {
    _levels = Levels.GetInstance();
    _currency = Currency.GetInstance();
    _instancesManager = gameObject.GetComponent<InstancesManager>();
  }
  public void Victory(int levelId)
  {
    _levels.UnlockLevel(levelId);
    _currency.Victory();
    _instancesManager.Destroy();
  }

  public void GameOver()
  {
    _currency.GameOver();
    _instancesManager.Destroy();
  }
}
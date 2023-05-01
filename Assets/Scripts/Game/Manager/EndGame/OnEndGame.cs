using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public sealed class OnEndGame : MonoBehaviour
{
  private InstancesManager _instancesManager;
  private Currency _currency;

  void Start()
  {
    _currency = Currency.GetInstance();
    _instancesManager = gameObject.GetComponent<InstancesManager>();
  }
  public void Victory()
  {
    _currency.Victory();
    _instancesManager.Destroy();
  }

  public void GameOver()
  {
    _currency.GameOver();
    _instancesManager.Destroy();
  }
}
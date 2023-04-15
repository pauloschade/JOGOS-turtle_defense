using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Money : MonoBehaviour  
{
  [SerializeField] private Cost totalMoney;
  private Currency currency;
  protected virtual void Start()
  {
    currency = Currency.GetInstance();
    totalMoney.Init(currency.balance);
  }

  void Update()
  {
    totalMoney.Init(currency.balance);
  }
}
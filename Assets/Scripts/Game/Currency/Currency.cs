using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public sealed class Currency : SingletonBase<Currency>
{
    public float balance;
    private static Treasury treasury;
    //generate ctor
    public void AddFunds(float amount)
    {
      balance += amount;
    }
    public void SpendFunds(float amount)
    {
      if(amount > balance) return;
      balance -= amount;
    }
    private void EndGame()
    {
      treasury.EndGame(balance);
    }

    protected override void Init()
    {
      treasury = Treasury.GetInstance();
      _instance.balance = treasury.StartGame();
    }
}
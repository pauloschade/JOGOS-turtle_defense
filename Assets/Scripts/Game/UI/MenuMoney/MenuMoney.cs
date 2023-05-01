using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuMoney : MonoBehaviour  
{
  [SerializeField] private Cost totalMoney; 
  [SerializeField] private Cost totalBank;
  [SerializeField] private TMP_InputField withdrawInput;
  [SerializeField] private TMP_InputField depositInput;

  private Treasury treasury;
  void Start()
  {
    treasury = Treasury.GetInstance();
  }

  void Update()
  {
    totalMoney.Init(treasury.GameBalance);
    totalBank.Init(treasury.BankBalance);
  }

  public void Withdraw()
  {
    treasury.Withdraw(float.Parse(withdrawInput.text));
  }
  public void Deposit()
  {
    treasury.Deposit(int.Parse(depositInput.text));
  }
}
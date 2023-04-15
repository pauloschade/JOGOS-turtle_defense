using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cost : MonoBehaviour  
{
  private int towerCost;
  [SerializeField] private TextMeshProUGUI coinText;
  public void Init(int towerCost) {
    this.towerCost = towerCost;
    Debug.Log("cost: " + towerCost);
    coinText.text = towerCost.ToString();
  }
}
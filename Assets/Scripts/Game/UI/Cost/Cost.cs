using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cost : MonoBehaviour  
{
  private float towerCost;
  [SerializeField] private TextMeshProUGUI coinText;
  public void Init(float towerCost) {
    this.towerCost = towerCost;
    coinText.text = towerCost.ToString();
  }
}
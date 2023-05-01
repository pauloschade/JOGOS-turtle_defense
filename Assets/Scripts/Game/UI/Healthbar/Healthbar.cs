using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour 
{
  [SerializeField] private Image healthImage;
  private float maxHealth;

  public void Init(float health) {
    this.maxHealth = health;
  }

  public void SetHealth(float health) {
    healthImage.fillAmount = health/maxHealth;
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour 
{
  //deactivate all UI elements

  private GameManager _gameManager;
  private bool _gameOver;
  private GameObject _gameOverUI;

  void Start()
  {
    _gameManager = GameManager.GetInstance();
    _gameOverUI = gameObject.transform.GetChild(0).gameObject;
    _gameOverUI.SetActive(false);
  }

  void Update()
  {
    if(_gameOver) return;
    if(_gameManager.GameOver) {
      _gameOverUI.SetActive(true);
      _gameOver = true;
    }
  }
}

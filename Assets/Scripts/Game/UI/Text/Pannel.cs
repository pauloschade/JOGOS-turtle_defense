using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pannel : MonoBehaviour 
{
  //deactivate all UI elements

  [SerializeField] private AudioSource audio;
  [SerializeField] private int _type;
  private GameManager _gameManager;
  private bool _canvaSet;
  private GameObject _canvaUI;

  void Start()
  {
    _gameManager = GameManager.GetInstance();
    _canvaUI = gameObject.transform.GetChild(0).gameObject;
    _canvaUI.SetActive(false);
  }

  void Update()
  {
    if(_canvaSet) return;
    if(Check()) {
      _canvaUI.SetActive(true);
      audio.Play(0);
      _canvaSet = true;
    }
  }

  private bool Check()
  {
    return _type == 0 ? _gameManager.GameOver : _gameManager.Victory;
  }
}

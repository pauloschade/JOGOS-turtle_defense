using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : SingletonBase<GameManager>
{
  public bool GameOver {get; private set; }
  public bool Victory {get; private set; }
  public int MaxEnemiesCount {get; private set; } = 0;
  private bool _isCountSet;

  public void SetEnemiesCount(int count)
  {
    if(_isCountSet) return;
    MaxEnemiesCount = count;
    _isCountSet = true;
  }

  public void SetGameOver()
  {
    if(Check()) return;
    if(MaxEnemiesCount > 0) {
      MaxEnemiesCount--;
      return;
    };
    MaxEnemiesCount = -1;
    GameOver = true;
    Debug.Log("Game Over");
  }

  public void SetVictory()
  {
    if(Check()) return;
    Victory = true;
  }

  private bool Check()
  {
    return Victory || GameOver;
  }
}
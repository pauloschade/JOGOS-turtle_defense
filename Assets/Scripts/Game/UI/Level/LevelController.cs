using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour 
{
  [SerializeField] private List<LevelSelection> levels;

  [SerializeField] private Levels unlocker;

  void Start()
  {
    unlocker = Levels.GetInstance();
  }

  void Update()
  {
    for(int i = 0; i < levels.Count; i++)
    {
      if(unlocker.levelArray[i] == true)
      {
        levels[i].unlocked = true;
      }
    }
  }

}
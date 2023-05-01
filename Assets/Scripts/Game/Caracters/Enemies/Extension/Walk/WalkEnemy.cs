using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class WalkEnemy : Enemy
{
  [SerializeField] protected List<Sprite> walkSpriteArray;
  private int walkSpriteIndex = 0;

  private float deltaTime = 0.0f;

  protected override void Update()
  {
    deltaTime += Time.deltaTime;
    ChangeAnimation();
    base.Update();
  }

  protected override void Translate()
  {
    gameObject.GetComponent<SpriteRenderer>().sprite = walkSpriteArray[walkSpriteIndex];
    base.Translate();
  }

  private void ChangeAnimation()
  {
    if (deltaTime >= 1/(speed*5))
    {
      if (walkSpriteIndex == walkSpriteArray.Count - 1) walkSpriteIndex = 0;
      deltaTime = 0.0f;
      walkSpriteIndex++;
    }
  }
}
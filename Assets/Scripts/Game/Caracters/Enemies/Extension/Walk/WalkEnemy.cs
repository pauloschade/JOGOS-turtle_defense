using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class WalkEnemy : Enemy
{
  [SerializeField] protected Sprite[] walkSpriteArray;
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
    if (walkSpriteIndex == walkSpriteArray.Length) walkSpriteIndex = 0;
    gameObject.GetComponent<SpriteRenderer>().sprite = walkSpriteArray[walkSpriteIndex];
    base.Translate();
  }

  private void ChangeAnimation()
  {
    if (deltaTime >= 1/(speed*5))
    {
      deltaTime = 0.0f;
      walkSpriteIndex++;
    }
  }
}
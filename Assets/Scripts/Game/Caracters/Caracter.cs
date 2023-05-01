using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public abstract class Caracter : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected Sprite[] spriteArray;
    [SerializeField] protected AudioSource audio;
    public int YPos { get; protected set;}
    public bool IsDead  { get; protected set;}

    public virtual void Start()
    {
      if(audio != null) audio = GameObject.Instantiate(audio);
    }

    public virtual void TakeDamage(float amount, int hitBox)
    {
      if (IsDead) return;
      if(YPos != hitBox) return;
      LoseHealth(amount);
      StartCoroutine(BlinkRed());
    }
    protected virtual void LoseHealth(float amount)
    {
      health -= amount;
      if (health > 0) return;
      IsDead = true;
      Die();
    }

    protected virtual IEnumerator Animate(float animationRate = 1) {
      if(spriteArray.Length == 0) yield return new WaitForSeconds(1/animationRate);
      for (int i = 0; i < spriteArray.Length; i++) {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[i];
        yield return new WaitForSeconds(1/animationRate/spriteArray.Length);
      }
    }

    private IEnumerator BlinkRed()
    {
        GetComponent<SpriteRenderer>().color=Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color=Color.white;
    }
    protected virtual void Die()
    {
      Destroy(gameObject);
    }
    protected abstract void SetYPos();
    public abstract int GetXPos();

}
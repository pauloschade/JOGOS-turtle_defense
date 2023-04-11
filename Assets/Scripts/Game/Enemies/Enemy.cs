using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected int attackRate;
    public bool IsDead  { get; private set;}

    void Start()
    {
      IsDead = false;
    }
    void Update()
    {
      if (IsDead) return;
      Translate();
    }
    protected virtual void Translate()
    {
      transform.Translate(-transform.right*speed*Time.deltaTime);
    }
}
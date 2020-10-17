using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    [Header("ATRIBUTOS INIMIGO")]
    [SerializeField] private int vida;
    [SerializeField] private int vidaMaxima;
    void Awake()
    {
        vida = 10;
        vidaMaxima = 50;
    }

    #region Colisores e Triggers
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiro")
        {
            RemoveHealth(5);
            Debug.Log("Dei trigger com: " + " " + gameObject.tag + " " + "Vida atual: " + this.vida);
        }
        if (other.gameObject.tag == "Player")
        {
            RemoveHealth(2);
            Debug.Log("Dei trigger com: " + " " + gameObject.tag + " " + "Vida atual: " + this.vida);  
        }
    }
    void OnCollisionEnter(Collision otherCollision)
    {
        if (otherCollision.gameObject.tag == "Tiro" || otherCollision.gameObject.tag == "Player")
        {
            RemoveHealth(1);
            Debug.Log("Colidi com" + " " + gameObject.tag + " " + "Vida atual: " + this.vida);
        }
    }
    #endregion
    #region EnemyLifeControl
    public int GetLife() => this.vida;
    public void SetLife(int lifePlayer)
    {
        if (lifePlayer >= vidaMaxima)
        {
            this.vida = vidaMaxima;
        }
        else
        {
            this.vida = lifePlayer;
        }
        if (vida <= 0)
        {
            enemyDeath();
        }
    }
    public void enemyDeath() => Destroy(gameObject);
    public void RemoveHealth(int life) => this.SetLife(this.vida - life);
    #endregion


}
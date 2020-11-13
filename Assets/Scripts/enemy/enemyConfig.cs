using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class enemyConfig : EnemyAI
{
    [Header("ATRIBUTOS INIMIGO")]
    [SerializeField] private int vida;
    [SerializeField] private int vidaMaxima;
    private int stamina;
    private int MaxStamina;
    [Header("PROPRIEDADES PARA ATIRAR")]
    private int ammo;
    private int magazines;
    private float timeToShoot;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletRef;


    void Awake()
    {
        vida = 10;
        vidaMaxima = 50;
        stamina = 350;
        MaxStamina = 450;
        ammo = 10;
        magazines = 3;
        timeToShoot = 3;

    }

    #region Colisores e Triggers

    void OnTriggerEnter(Collider other)
    {

        //Fazer várias verificações de IF é pesado, ainda mais quando não está usando ELSE IF

        if (other.gameObject.tag == "Tiro" || other.gameObject.tag == "pistolShoot")
        {
            RemoveHealth(5);
            Debug.Log("Dei trigger com: " + " " + gameObject.tag + " " + "Vida atual: " + this.vida);
        }
        else if (other.gameObject.tag == "Player")
        {
            RemoveHealth(2);
            Debug.Log("Dei trigger com: " + " " + gameObject.tag + " " + "Vida atual: " + this.vida);
        }
        else if (other.gameObject.tag == "enemyShoot")
        {
            RemoveHealth(5);
        }

        /* 
		uma boa forma de melhorar esse código é usar o switch
		creio que seja uma das melhores formas de melhorar
		*/

        /*switch (other.gameObject.tag)
        {
            case "Tiro":
                RemoveHealth(5);
                Debug.Log("Dei trigger com: " + " " + gameObject.tag + " " + "Vida atual: " + this.vida);
                break;
            case "pistolShoot":
                RemoveHealth(2);
                Debug.Log("Dei trigger com: " + " " + gameObject.tag + " " + "Vida atual: " + this.vida);
                break;
            default:
                break;
        }*/
    }

    void OnCollisionEnter(Collision otherCollision)
    {
        if (otherCollision.gameObject.tag == "Tiro" || otherCollision.gameObject.tag == "Player")
        {
            RemoveHealth(1);
            Debug.Log("Colidi com" + " " + gameObject.tag + " " + "Vida atual: " + this.vida);
        }
        else if (otherCollision.gameObject.tag == "enemyShoot")
        {
            RemoveHealth(5);
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
            //enemyDeath();
            killPlayer();
            WinOrLose Test = new WinOrLose();
            Test.WinCondition();
        }
    }
    /*
	essa nomenclatura não faz tanto sentido, cairia como um Event e não Method
	public void enemyDeath() => Destroy(gameObject);
	*/
    public void killPlayer() => Destroy(gameObject);


    public void RemoveHealth(int life) => this.SetLife(this.vida - life);
    #endregion
    #region NavMashConfig And StaminaConfig

    /*
	essa nomenclatura também não faz sentido, já que queremos retornar uma Boolean a melhor forma é sempre começar com "is"
	public bool enemyExhausted() => this.stamina <= 0;
	*/
    public bool isEnemyExhausted() => this.stamina <= 0;

    public int GetStamina() => this.stamina;

    public void SetStamina(int stamina)
    {
        if (IsGamePaused())
        {
            return;
        }
        if (!CooldownManager.IsExpired("enemy", "stamina"))
        {
            return;
        }
        CooldownManager.AddCooldown("enemy", "stamina", 500);

        this.stamina = stamina;

        if (this.stamina > this.MaxStamina)
        {
            this.stamina = this.MaxStamina;
        }
        if (this.stamina <= 0)
        {
            this.stamina = 0;
        }

    }
    public void AddStamina(int stamina) => this.SetStamina(this.GetStamina() + stamina);
    public void RemoveStamina(int stamina) => this.SetStamina(this.GetStamina() - stamina);
    public void FindPlayer()
    {
        trackPlayer();
        RemoveStamina(10); 
        if (this.isEnemyExhausted())
        {
            GameObject enemyObj = GameObject.Find("Inimigo");
            enemyObj.GetComponent<NavMeshAgent>().enabled = false;
        }

    }
    #region enemyShooting
    public void GetTarget()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            return;
        }
    }
    private GameObject enemyShoot;
    private float timeDestroyShoot = 3f;
    public void EnemyShoting()
    {
        GetTarget();
        if (!CooldownManager.IsExpired("TiroInimigo", "FireHate"))
        {
            return;
        }
        CooldownManager.AddCooldown("TiroInimigo", "FireHate", 500);
        shooting();
    }
    public void shooting()
    {
        if (ammo > 0)
        {
            //shootEffect();
            ammo--;
            Instantiate(bullet, bulletRef.position, bulletRef.rotation);
            timeToShoot = 0;
        }
        if (ammo == 0 && magazines > 0)
        {
            magazines -= 1;
            ammo = 10;
        }
    }
    [SerializeField] private AudioSource gunSFX;
    public void shootEffect() => gunSFX.Play();
    public void DestroyProjectile() => Destroy(gameObject, timeDestroyShoot);
    public bool IsGamePaused()
    {
        return Time.timeScale == 0;
    }
}
#endregion
#endregion

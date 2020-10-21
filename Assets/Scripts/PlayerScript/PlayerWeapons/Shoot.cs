using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Atributos_Munição")]
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeDestroyShoot;
    //[Header("gameObject")]
    //[SerializeField] private GameObject project;
    void Awake()
    {
        timeDestroyShoot = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        bulletSpeed = 150 * Time.deltaTime;
        transform.Translate(0, 0, bulletSpeed);
        DestroyProjectile();
    }
    public void DestroyProjectile() => Destroy(gameObject, timeDestroyShoot);
    
    /*public void InstanciateShoot()
    {
        Rigidbody instantiatedProjectile = Instantiate(rb, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.forward * shootspeed;
        DestroyShoot(instantiatedProjectile);
    }
    private float projectDestroyTime;
    public void DestroyShoot(Rigidbody project) => Destroy(project.gameObject, projectDestroyTime);
    */
}

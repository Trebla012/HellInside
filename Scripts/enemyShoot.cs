using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour {

    //Script para el disparo del enemigo

    public bool isAI;
    public GameObject Bullet;  //Bala
    public Transform SpawnPoint; //De donde salen las balas

    public float proyectileSpeed;

    //CoolDown
    public float CoolDown = 0.35f;
    private float nextFire = 0f;


    // Update is called once per frame
    void Update()
    {
        //Al ser IA, dispara automáticamente
        bool isShooting = (!isAI && Input.GetButton("Shoot")) || isAI;


        if (isShooting && CoolDownTimer(CoolDown, nextFire))
        {
            //Instanciación y movimiento de la bala
            GameObject EnemyProjectile = (GameObject)Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            EnemyProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(proyectileSpeed * -gameObject.transform.localScale.x, 0);

                nextFire = Time.time;
              
            
        }

    }

    //Cooldown del disparo
    public bool CoolDownTimer(float coolDown, float nextFire)
    {
        return Time.time - nextFire > CoolDown;
    }

}

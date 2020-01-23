using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    //Script para disparar (Similar el del enemigo)

    public bool isAI;
    public GameObject Bullet;
    public Transform SpawnPoint;
    public Animator anim;
    public float arrowSpeed;

    //CoolDown
    public float CoolDown = 0.35f;
    private float nextFire = 0f;

    void Update()
    {
        //Al no ser IA, si apretamos la tecla de shot disparará teniendo en cuenta el cooldown

        bool isShooting = (!isAI && Input.GetButtonDown("Shoot")) || isAI;


        if (isShooting && CoolDownTimer(CoolDown, nextFire) )
        {

            anim.SetBool("Shooting", true); //Animación de disparo

            //InstantiateBullet();
           
            nextFire = Time.time;
              
            
        }
        else
        {
            anim.SetBool("Shooting", false);
        }

    }

    //Función para instanciar la bala y darle una dirección y velocidad
    public void InstantiateBullet()
    {
        GameObject Arrow = (GameObject)Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
        Arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed * gameObject.transform.localScale.x, 0);

    }

    //Cooldown
    public bool CoolDownTimer(float coolDown, float nextFire)
    {
        return Time.time - nextFire > CoolDown;
    }

 
}

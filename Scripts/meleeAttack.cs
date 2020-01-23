using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAttack : MonoBehaviour {

    //Script para realizar el ataque melee

    public bool isAI;
  
    public Animator anim;

    public GameObject bc;

    //CoolDown
    public float CoolDown = 0.35f;
    private float nextAttack = 0f;

    //Busca nuestro trigger de daño al atacar

    private void Start()
    {
        bc = GameObject.Find("AttackTrigger");
    }


    void Update()
    {
        //Al no ser IA y apretar la tecla de melee se activa el trigger teniendo en cuanta el cooldown

        bool isAttacking = (!isAI && Input.GetButton("Melee")) || isAI;


        if (isAttacking && CoolDownTimer(CoolDown, nextAttack))
        {
            bc.SetActive(true);
          
            anim.SetBool("Melee", true);
        }
        else
        {

            bc.SetActive(false);
            anim.SetBool("Melee", false);
        }
    }

    //Función de cooldown
    public bool CoolDownTimer(float coolDown, float nextAttack)
    {
        return Time.time - nextAttack > CoolDown;
    }


}
    


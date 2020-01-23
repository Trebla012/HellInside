using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    //Script con la misma función que de meleeAttack del player pero para el enemigo

    public bool isAI;

    public Animator anim;

    public GameObject bc;

    public float CoolDown = 0.35f;
    private float nextAttack = 0f;


    private void Start()
    {
        bc = GameObject.Find("EnemyAttackCollider");
    }

    // Update is called once per frame
    void Update()
    {
        bool isAttacking = (!isAI && Input.GetButton("Melee")) || isAI;


        if (isAttacking && CoolDownTimer(CoolDown, nextAttack))
        {
            bc.SetActive(true);

        }
        else
        {

            bc.SetActive(false);
        }
    }

    public bool CoolDownTimer(float coolDown, float nextAttack)
    {
        return Time.time - nextAttack > CoolDown;
    }


    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    //script que hace la misma función que attack pero contra el player

    public int Damage; //El daño de este ataque.
    public bool DestroyThisGameObject = true; //para las balas
    [HideInInspector]
    public bool canAttack;

    private void Start()
    {
        canAttack = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Player" && canAttack)
        {
            HealthSystem hs = col.GetComponent<HealthSystem>();
            if (hs)
            {
                hs.SetDamage(Damage);

            }
        }
    }
}

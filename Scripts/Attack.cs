using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    //Script para hacer daño con trigger

    public int Damage; //El daño de este ataque.
    public bool DestroyThisGameObject = true; //Destruir las balas

    //Compara tag enemy para aplicar daño
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealthSystem hs = collision.GetComponent<EnemyHealthSystem>();
            if (hs)
            {
                hs.SetDamage(Damage);

                if (DestroyThisGameObject)
                    Destroy(gameObject);
            }
            //Compara tag boss para aplicar daño
        } else if (collision.CompareTag("Boss"))
        {
            BossHealthSystem bs = collision.GetComponent<BossHealthSystem>();
            if (bs)
            {
                bs.SetDamage(Damage);

                if (DestroyThisGameObject)
                    Destroy(gameObject);
            }
        }
        //Compara tag enemymelee para aplicar daño
        else if (collision.CompareTag("EnemyMelee"))
        {
            EnemyMeleeHealthSystem hms = collision.GetComponent<EnemyMeleeHealthSystem>();
            if (hms)
            {
                hms.SetDamage(Damage);

                if (DestroyThisGameObject)
                    Destroy(gameObject);
            }
        }
    }
}

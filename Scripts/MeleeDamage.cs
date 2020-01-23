using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    //Script que hace lo mismo que attack pero de tipo melee y sin destroy de gameobject

    public int meleeDamage;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealthSystem hs = collision.GetComponent<EnemyHealthSystem>();
            if (hs)
            {
                hs.SetDamage(meleeDamage);

            }
        }
        else if (collision.CompareTag("Boss"))
        {
            BossHealthSystem bs = collision.GetComponent<BossHealthSystem>();
            if (bs)
            {
                bs.SetDamage(meleeDamage);
             
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            EnemyMeleeHealthSystem hms = collision.GetComponent<EnemyMeleeHealthSystem>();
            if (hms)
            {
                hms.SetDamage(meleeDamage);

            }
        }
    }
}

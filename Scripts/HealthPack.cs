using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour {
  
    //Script para la recolección de packs de salud (similar al de munición)

        public int HealingCapacity;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                HealthSystem hs = collision.GetComponent<HealthSystem>();
                if (!hs.isFullHealth)
                {
                    hs.SetHealth(HealingCapacity);
                    Destroy(gameObject);
                }

                //incluso si tenemos la vida a tope, consumimos el pack
                if (hs.PickHealthPackAtFull && hs.isFullHealth)
                    Destroy(gameObject);
            }
        }
    }

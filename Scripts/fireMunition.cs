using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMunition : MonoBehaviour
{
    //Script de recolección de munición por parte del player

    public bool PickHealthPackAtFull;
    public int munitionCapacity;
    
    //Al tocar el trigger se almacena en la varible munición
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            throwAttack ta = collision.GetComponent<throwAttack>();  
                ta.SetMunition(munitionCapacity);
                Destroy(gameObject);
            
        }
    }
}

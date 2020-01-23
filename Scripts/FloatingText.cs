using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    //Script que trabaja sobre el textoo de daño a los enemigos
    
    public Vector3 offSet = new Vector3(0, 10, 0); //Posición del texto
    void Start()
    {

        Destroy(gameObject, 2f); //Lo destruye tras 2 segundos
        transform.localPosition += offSet;
    }

}
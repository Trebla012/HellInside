using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    //Script con la misma función que el de bullet pero para enemigos

    public float lifeTime = 5.0f;

    void Awake()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Update()
    {

    }

}


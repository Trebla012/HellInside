using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //Script de vida de la bala de player 

        public float lifeTime = 5.0f;

        void Awake()
        {
            Destroy(this.gameObject, lifeTime);
        }

        private void Update()
        {

      
        }
    }
    

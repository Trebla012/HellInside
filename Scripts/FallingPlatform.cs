using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    //Script de caida de plataformas trampa

    public float fallDelay = 0.5f;

    Rigidbody2D rb;
    BoxCollider2D bc;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();  //Obtenemos si rigidbody y su box collider
        bc = GetComponent<BoxCollider2D>();
	}
	
    //Si tocamos el trigger se cae
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Invoke("fall", fallDelay);
        }
    }

    //Caida más realista
    void fall()
    {
        rb.isKinematic = false;
        bc.isTrigger = true;
    }
}

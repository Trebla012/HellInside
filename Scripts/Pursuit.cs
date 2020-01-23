using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : MonoBehaviour {

    //variables de radio de visión y velocidad
    public float visionRadius;
    public float speed = 5;
    float orientation;

    //variable para guardar al jugador
    GameObject player;
    Animator anim;

    //variable para guardar la posición inicial
    Vector3 initialPosition;
    private Rigidbody2D rb2d;
    bool facingRight = true;
    SpriteRenderer myRenderer;

    void Start()
    {
        //Recuperamos al jugador gracias al Tag
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();

        //Guardamos nuestra posición inicial
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        float currentSpeed = 0;
        Vector3 target = Vector3.zero;

        //Comprueba que la distancia del player es menor que la distancia de visión y lo sigue, sino se queda quieto
        float dist = Vector3.Distance(player.transform.position, transform.position);

        orientation = Mathf.Sign((player.transform.position.x - transform.position.x));

        if (dist < visionRadius)
        {
            target = player.transform.position;
            currentSpeed = speed;
        }
        else
            currentSpeed = 0;
        anim.SetFloat("Run", currentSpeed);
        Flip();
        rb2d.velocity = new Vector2(currentSpeed * orientation, rb2d.velocity.y);

    }

    //Función para flipear el sprite renderer
    void Flip()
    {
        myRenderer.flipX = -Mathf.Sign(orientation) < 0;
    }
}
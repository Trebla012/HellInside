using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //Script principal de control del personaje

    public float maxSpeed = 10f; //Variable de velocidad

    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator anim;
    public bool grounded = false;

    public Transform groundCheck; //Check del suelo
    float groundRadius = 0.2f;
    public LayerMask WhatIsGround; 
    public float JumpForce = 18f;
    GameObject Hero;

    //esta caja y sus dimensionales la usamos para detectar cuando tocamos algo de frente
    //y cancelar la velocity hacia delante.
    public Transform FrontalBoxProjectionPos;
    public Vector2 FrontalBoxDimensions;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Obtiene todos los componentes necesarios 
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        //comprobamos que toque el suelo
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, WhatIsGround);
        anim.SetBool("Ground", grounded);

        //devolvemos los colliders golpeados y cambiamos el input
        float move = Input.GetAxisRaw("Horizontal");

        //aplicamos la animación
        anim.SetFloat("Speed", Mathf.Abs(move));

        //guardamos el vector resultante
        Vector2 playerVelocity = new Vector2(move * maxSpeed, rb.velocity.y);

        //Si se mueve a la derecha su escala es la normal
        if (move != 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(move));
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * maxSpeed, rb.velocity.y);
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal") * 1, 1, 1);
        }
        //Si se mueve a izquierda la escala es -1 en x y rota el personaje
        else 
        {
            anim.SetFloat("Speed", Mathf.Abs(move));
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


    }

    private void Update()
    {
        //Las acciones One-Hit las podemos poner en Update para no tener input loss.
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }



    }


  
}

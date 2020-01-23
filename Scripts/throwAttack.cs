using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class throwAttack : MonoBehaviour {

    //Script para lanzar las bolas de fuego por parte del player

    public AudioSource munitionSound; //Sonido del lanzamiento

    public GameObject projectile;
    public Vector2 velocity;
    bool canShoot = true;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public float cooldown = 1f;

    [HideInInspector] public bool isMaxMunition;

    [HideInInspector] public int maxMunition = 3;

    [HideInInspector] public int munition;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        munition = maxMunition; //Munición inicial al máximo
        isMaxMunition = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Si apretamos la I y puede lanzar ya sea por la munición o el cooldown, lanza

        if (Input.GetKeyDown(KeyCode.I) && canShoot)
        {
            anim.SetBool("Throw", true);//Animación de lanzar
     
            munition--;

            Debug.Log("Current munition: " + munition);

            StartCoroutine(CanShoot());

           

        }
        else

            anim.SetBool("Throw", false);
    }

    void CanThrow()
    {
        GameObject go = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * (Mathf.Abs(transform.localScale.x)), Quaternion.identity);

        go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
    }

    //Función de munición y obtención por parte de los packs
    public void SetMunition(int munitionCapacity)
    {
        munition = (munition + munitionCapacity);
        munitionSound.Play();
        if (munition >= maxMunition)
        {
            munition = maxMunition;
        }
        else
            StartCoroutine(CanShoot());
        Debug.Log("Current munition: " + munition);

 
    }

    //Corrutina que comprueba el cooldown
    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        if (munition <= 0)

            canShoot = false;
         
        else
        
            canShoot = true;
        

    }

    //La munición actual aparece en pantalla y va variando según su uso
    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUILayout.Label("  Fire Munition: " + munition);

    }
}


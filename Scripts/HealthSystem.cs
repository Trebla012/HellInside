using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour {

    //Script que trabaja sobre la salud del player

    public GameObject deadText;

    public AudioSource potionSound; //Sonidos de poción, daño y muerte
    public AudioSource damageSound;
    public AudioSource gameOverSound;

    public GameObject pf;  //Activa los 3 estados (en canvas) de la miniatura de la cabeza
    public GameObject hf;
    public GameObject df;

    PlayerController hero; //4 scripts de ataque que se desactivarán cuando muera
    Shoot shoot;
    throwAttack fireball;
    meleeAttack melee;

    Rigidbody2D rb;
    public HealthUI healthUI; //Llama a la barra de vida 
    public int MaxHealthPoints;
    public bool PickHealthPackAtFull;
    public float InmunityTime;
    [HideInInspector] public bool isFullHealth; //Variables para comprobar si tiene toda la vida, si es inmune o si ha muerto
    [HideInInspector] public bool isInmuneState;
    [HideInInspector] public bool isDead;

    public Animator anim; //Llama al animator

    int CurrentHealthPoints;
    float CurrentInmunityCounter;

    // Start is called before the first frame update
    void Start()

    {
        melee = GetComponent<meleeAttack>(); //Asignamos a la variable los scripts antes mencionados

        fireball = GetComponent<throwAttack>();

        shoot = GetComponent<Shoot>();

        hero = GetComponent<PlayerController>();

        rb = GetComponent<Rigidbody2D>();

        CurrentHealthPoints = MaxHealthPoints;  //Pone la vida al máximo al empezar
        isFullHealth = true;

        if (healthUI)
            healthUI.SetMaxHealthUI(MaxHealthPoints);

    }

    //Al morir, nos saldrá una pantalla que al apretar R nos devolverá al principio
    private void Update()
    {
        if (isDead == true)
        {

            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


            return;

        }
    }
    //Función para restar puntos de daño a la vida y llamar a la corrutina de inmunidad o la función de muerte
    public void SetDamage(int DamagePoints)
    {
        if (!isInmuneState && !isDead)
        {
            CurrentHealthPoints -= DamagePoints;
            damageSound.Play();

            isFullHealth = false;
            if (CurrentHealthPoints <= 0)
            {
                CurrentHealthPoints = 0;
                Die();
            }
            else
            {
                StartCoroutine(SetInmunity());
            }

            if (healthUI)
                healthUI.ChangeAvatarHealthUI(CurrentHealthPoints);

            Debug.Log("Damaging " + gameObject.name + ": " + DamagePoints +
                            ", current health: " + CurrentHealthPoints);

        }
    }

  
    //Función de curación
    public void SetHealth(int HealthPoints)
    {
        CurrentHealthPoints = (CurrentHealthPoints + HealthPoints) > MaxHealthPoints ?
            MaxHealthPoints : CurrentHealthPoints + HealthPoints;
        potionSound.Play();
        Debug.Log("Restoring " + HealthPoints + ", current health: " + CurrentHealthPoints);
        isFullHealth = CurrentHealthPoints == MaxHealthPoints;
        if (healthUI)
            healthUI.ChangeAvatarHealthUI(CurrentHealthPoints);
    }

    //Función de muerte
    public void Die()
    {
        gameOverSound.Play();
        isDead = true;
        anim.SetBool("Dead", true); //Animación de morir
        pf.SetActive(false);
        hf.SetActive(false);
        df.SetActive(true);
        melee.enabled = false; //Aquí es donde desactivamos los scripts al morir
        fireball.enabled = false;
        shoot.enabled = false;
        hero.enabled = false;
        deadText.SetActive (true);


       
    }
    //Corrutina de inmunidad
    IEnumerator SetInmunity()
    {
        isInmuneState = true;
        //podemos hacer que el material de nuestro renderer
        //nos deje al 50% de alpha
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(1, 1, 1, 0.5f);
        anim.SetBool("Hurt", true); //Animación de dolor
        pf.SetActive(false);  //Activamos y desactivamos los canvas de los estados de la miniatura
        hf.SetActive(true);
        yield return new WaitForSeconds(InmunityTime);
        renderer.material.color = new Color(1, 1, 1, 1);
        anim.SetBool("Hurt", false);
        pf.SetActive(true);
        hf.SetActive(false);
        isInmuneState = false;
    }

}

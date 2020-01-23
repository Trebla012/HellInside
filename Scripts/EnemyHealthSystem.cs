using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour {

    //Script de salud para los enemigos que atacan a distancia

    public GameObject PrefabFloatingText; //Prefab para que se vea el daño recibido

    public AudioSource enemyDamageSound; //Audio del daño

    enemyAI move;  //2 scripts de ataque desactivaremos cuando muera
    enemyShoot shoot;

    public EnemyHealthUI enemyHealthUI;  //Llama a la barra de vida 
    public int EnemyMaxHealthPoints;
    public float InmunityTime;
    [HideInInspector] public bool isFullHealth;  //Variables para comprobar si tiene toda la vida, si es inmune o si ha muerto
    [HideInInspector] public bool isInmuneState;
    [HideInInspector] public bool isDead;

    public Animator anim;  //Llama al animator

    int CurrentHealthPoints;
    float CurrentInmunityCounter;

    // Start is called before the first frame update
    void Start()
    {

        shoot = GetComponent<enemyShoot>(); //Asignamos a la variable los scripts antes mencionados
        move = GetComponent<enemyAI>();

        CurrentHealthPoints = EnemyMaxHealthPoints; //Pone la vida al máximo al empezar
        isFullHealth = true;

        if (enemyHealthUI)
            enemyHealthUI.SetEnemyMaxHealthUI(EnemyMaxHealthPoints);

    }

    //Función para restar puntos de daño a la vida y llamar a la corrutina de inmunidad o la función de muerte
    public void SetDamage(int DamagePoints)
    {
        if (!isInmuneState && !isDead)
        {
            CurrentHealthPoints -= DamagePoints;

            enemyDamageSound.Play();

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

            if (PrefabFloatingText)
            {
                ShowFloatingText();
            }

            if (enemyHealthUI)
                enemyHealthUI.ChangeAvatarHealthUI(CurrentHealthPoints);

        }
    }
    //Función para enseñar los puntos de daño en forma de texto encima del enemigo
    void ShowFloatingText()
    {
       var go = Instantiate(PrefabFloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = CurrentHealthPoints.ToString();
    }

    //Función de muerte
    public void Die()
    {
        isDead = true;
        anim.SetBool("Dead", true); //Animación de morir
        move.enabled = false;//Aquí es donde desactivamos los scripts al morir
        shoot.enabled = false;
        Destroy(gameObject,1f);
    }
    //Corrutina de inmunidad
    IEnumerator SetInmunity()
    {
        isInmuneState = true;
        //podemos hacer que el material de nuestro renderer
        //nos deje al 50% de alpha
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(InmunityTime);
        renderer.material.color = new Color(1, 1, 1, 1);
        isInmuneState = false;
    }

}
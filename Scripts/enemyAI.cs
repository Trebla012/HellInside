using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyAI : MonoBehaviour {

    //Script para la inteligencia artificial de los Imp

    public Transform target;

    SpriteRenderer sp;

    public float speed = 200f;
    public float NextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    public Transform enemyGFX;

    Seeker seeker;
    Rigidbody2D rb;


    // Use this for initialization
    void Start() {

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    //Segui el camino planteado por el seeker

	void Update () {

        if (path == null)
        {
            return;
        }

        if(currentWaypoint>= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        //Movimiento del Imp

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        //Calcula la distancia con el objetivo

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < NextWaypointDistance)
        {
            currentWaypoint++;
        }

        //Según la orientación rota o no por su escala

        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f)
        { 
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }

	}
}

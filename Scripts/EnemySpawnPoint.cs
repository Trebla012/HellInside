using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {

    //Script de spawn de enemigos 

    public GameObject enemy; //Enemigo a spawnear
    float randX; //Rango en x para spawnear
    Vector2 wheresToSpawn; //Vector por el eje x para el spawn
    public float spawnRate = 2f;
    float nextSpawn = 0f;

	
	// Update is called once per frame
	void Update () {
        //Cada x segundos spawnea un enemigo
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(62.3f, 74.4f);
            wheresToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, wheresToSpawn, Quaternion.identity);
        }

	}
}

using UnityEngine;
using System.Collections;

public class ControlsText : MonoBehaviour {

    //Script para activar el canvas de los controles del player 

	public GameObject tooltip;


    //Al pasar por el trigger lo activa
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
						tooltip.SetActive (true);

		}
    //Al salir del trigger lo desactiva
	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player")
			tooltip.SetActive (false);
		
	}
}

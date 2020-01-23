using UnityEngine;
using System.Collections;

public class SwitchScript : MonoBehaviour {


    //Script que activa la puerta al pisar el botón

	public DoorTrigger[] doorTrig;

	Animator anim;
	public bool sticks; //Elige entre pulsar el trigger y que se quede o que se cierre al poco de pulsarlo

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
    //Se acciona al estar encima
	void OnTriggerStay2D()
	{
		anim.SetBool ("goDown", true);

		foreach (DoorTrigger trigger in doorTrig) {

			trigger.Toggle(true);

				}

	}
    //Si está stick se queda, sino se va cerrando
	void OnTriggerExit2D()
	{
		if(sticks)
			return;

		anim.SetBool ("goDown", false);

		foreach (DoorTrigger trigger in doorTrig) {
			
			trigger.Toggle(false);
			
		}





	}


}

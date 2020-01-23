using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

    //Script que anima y abre la puerta

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	public void DoorOpens()
	{
		anim.SetBool ("Opens", true);
		}

	public void DoorCloses()
	{
		anim.SetBool ("Opens", false);
	}

	void CollEnable()
	{
		GetComponent<Collider2D>().enabled = true;
	}

	void CollDisable()
	{
		GetComponent<Collider2D>().enabled = false;
	}



}

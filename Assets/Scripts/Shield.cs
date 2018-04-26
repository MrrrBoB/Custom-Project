using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
	Collider2D wallL;
	Collider2D wallT;
	Collider2D wallR;
	public GameObject player;
	public GameObject[] shields = new GameObject[3];
	public void Awake(){
		
		wallL = shields [0].GetComponent<Collider2D> ();
		wallT = shields [1].GetComponent<Collider2D> ();
		wallR = shields [2].GetComponent<Collider2D> ();
		wallL.enabled = false;
		wallT.enabled = false;
		wallR.enabled=false;
		player = FindObjectOfType<CharacterMovement2D> ().gameObject;

	}


	public void toggle(int facing){
		switch (facing) 
		{
		case -1:
			wallL.enabled = true;
			wallT.enabled = false;
			wallR.enabled = false;
			break;
		case 0:
			wallT.enabled = true;
			wallL.enabled = false;
			wallR.enabled = false;
			break;
		case 1:
			wallR.enabled = true;
			wallL.enabled = false;
			wallT.enabled = false;
			break; 
		default:
			wallL.enabled = false;
			wallT.enabled = false;
			wallR.enabled = false;
			break;
		}

				
		}
	public void off()
	{
		wallL.enabled = false;
		wallT.enabled = false;
		wallR.enabled = false;
	}


	// Use this for initialization

	
	// Update is called once per frame

}

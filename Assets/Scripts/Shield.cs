using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
	Collider2D wall;
	public GameObject player;
	public int side;
	public void Start(){
		wall = GetComponent<Collider2D> ();
		wall.enabled = false;
		player = FindObjectOfType<CharacterMovement2D> ().gameObject;
	}


	public void toggle(int facing){
		
			if (side == facing&&Input.GetMouseButton (1)) {
				wall.enabled = true;
			} else
				wall.enabled = false;
		}
		


	// Use this for initialization

	
	// Update is called once per frame

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
	Collider2D wall;
	public GameObject player;
	public void Start(){
		wall = GetComponent<Collider2D> ();
		wall.enabled = false;
		player = FindObjectOfType<CharacterMovement2D> ().gameObject;
	}
	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow)) {
			wall.enabled=true;
		}
		if(Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.DownArrow)){
				wall.enabled=false;
			}
	}

	// Use this for initialization

	
	// Update is called once per frame

}

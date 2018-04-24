using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlPortal : MonoBehaviour {
	private GameManager manager;
	// Use this for initialization
	void Awake () {
		manager = FindObjectOfType<GameManager> ();
	}
	
	public void OnTriggerEnter2D(Collider2D obj){
		if (obj.gameObject.tag == "Player") {
			manager.LoadNextLevel ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {
	public GameObject spawn;
	// Use this for initialization
	void Start () {
		spawn = GameObject.Find("SpawnPoint");
		
	}
	
	public void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			transform.Translate (140, 0, 0);

		}
	}
}

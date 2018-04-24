using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("fell in pit");
			obj.gameObject.GetComponent<Health> ().ChangeHealth (obj.gameObject.GetComponent<Health> ().HP*-1);
		}
	}
}

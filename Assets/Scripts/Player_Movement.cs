using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
	public bool isgrounded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis ("Horizontal");
		transform.Translate(x, 0, 0);

		
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.transform.tag == "ground") {
			isgrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.transform.tag == "ground") {
			isgrounded = false;
		}
	}
}

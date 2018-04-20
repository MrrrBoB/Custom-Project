using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour {

	// Use this for initialization
	private bool moving;

	private void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			moving = true;
			obj.collider.transform.SetParent (transform);
		}
	}
	private void OnCollisionExit2D(Collision2D obj)
	{
		obj.collider.transform.SetParent (null);
		moving = false;
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	public int direction;
	public float speed;
	public float directionTime;
	// Use this for initialization
	void Start () {
		StartCoroutine ("routine");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.05f*(speed*direction), 0, 0);
	}
	public void Turn ()
	{
		direction *= -1;

	}
	private IEnumerator routine()
	{
		while (true) {
			yield return new WaitForSeconds (directionTime);
			Turn ();


		}
	}
}

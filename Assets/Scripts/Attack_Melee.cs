﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee : MonoBehaviour {
	public float swingRange;
	public int attDmg;
	public int hitcount=0;
	public LayerMask enemyLayer;
	private Animator KnightAnimator;
	// Use this for initialization
	void Start () {
		KnightAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame

	public void Swipe(int facing)
	{
		
		KnightAnimator.SetTrigger ("Attack");
		Vector2 position = transform.position;
		Vector2 direction;

		switch (facing) {
		case -1:
			direction = new Vector2(swingRange*-1, 0);
			break;
		case 1:
			direction = new Vector2(swingRange, 0);
			break;
		case 0:
			direction = new Vector2(0, swingRange);
			break;
		default:
			direction = Vector2.up;
			break;
		}
		//Debug.DrawRay (position, direction, Color.green, .25f);
		RaycastHit2D hit = Physics2D.Raycast(position, direction, swingRange, enemyLayer);
		if (hit.collider != null) {
			hit.collider.gameObject.GetComponent<Health> ().ChangeHealth (attDmg * -1);


			Debug.Log ("you smacked the chicken");
		}
		hitcount++;
		Debug.Log (hitcount);
	}
}
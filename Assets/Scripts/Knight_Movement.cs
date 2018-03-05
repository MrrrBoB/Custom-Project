using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour {
	private Rigidbody2D rigid;
	public float speed;
	public bool dead = false;
	Animator KnightAnimator;

	public float directionH;

	// Use this for initialization
	void Start () {
		KnightAnimator =GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rigid.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * speed, 0), ForceMode2D.Force);
		directionH = Input.GetAxis ("Horizontal");
		KnightAnimator.SetFloat ("Phase", Input.GetAxisRaw ("Horizontal"));
	}
		
	

}

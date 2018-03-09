using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour {
	private Rigidbody2D rigid;
	public float speed;
	public float jump;
	public bool dead = false;
	public bool isgrounded;
	Animator KnightAnimator;

	public float directionH;

	// Use this for initialization
	void Start () {
		KnightAnimator =GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Vertical")==0&&!Input.GetButton("Fire1"))
		rigid.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * speed, 0), ForceMode2D.Force);
		directionH = Input.GetAxis ("Horizontal");
		KnightAnimator.SetFloat ("PhaseV", Input.GetAxisRaw ("Vertical"));

		KnightAnimator.SetFloat ("Phase", Input.GetAxisRaw ("Horizontal"));
		if (Input.GetButton("Fire1")) {
			KnightAnimator.SetTrigger ("Attack");
		}

		if (Input.GetButtonDown ("Jump")&&isgrounded) {
			rigid.AddForce (new Vector2 (0, jump), ForceMode2D.Force);
		}
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

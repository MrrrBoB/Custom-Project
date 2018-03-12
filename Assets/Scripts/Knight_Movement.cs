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
	public ParticleSystem sparkles;

	public float directionH;

	// Use this for initialization
	void Start () {
		KnightAnimator =GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
		sparkles = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis ("Horizontal");

		if ((!isgrounded)||Input.GetAxisRaw("Vertical")==0&&!Input.GetButton("Fire1"))
			transform.Translate(x/5, 0, 0);
		directionH = Input.GetAxis ("Horizontal");
		KnightAnimator.SetFloat ("PhaseV", Input.GetAxisRaw ("Vertical"));
		if (Input.GetAxisRaw ("Vertical") < 0) {
			GlimmerPlay ();
		} else
			GlimmerPause ();
	
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
	
	public void GlimmerPlay()
	{
		
		sparkles.Play();
	}
	public void GlimmerPause()
	{
		
		sparkles.Pause();
	}
}

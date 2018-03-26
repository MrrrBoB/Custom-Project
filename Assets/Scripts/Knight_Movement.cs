using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour {
	private Rigidbody2D rigid;
	public float speed;
	public float jump;
	public bool iframe;
	public float swingRange;
	private bool lookLeft;


	public LayerMask groundLayer;
	private Animator KnightAnimator;
	public ParticleSystem sparkles;

	public float directionH;

	// Use this for initialization
	void Start () {
		KnightAnimator =GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
		//sparkles = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis ("Horizontal");
		transform.Translate(x/4, 0, 0);
	
		lookLeft = (x < 0);
		KnightAnimator.SetFloat ("PhaseV", Input.GetAxisRaw ("Vertical"));


	
		KnightAnimator.SetFloat ("Phase", Input.GetAxisRaw ("Horizontal"));
		if (Input.GetButton("Fire1")) {
			KnightAnimator.SetTrigger ("Attack");
			Swipe ();
		}

		if (Input.GetButtonDown ("Jump")) {
			


			if (isGrounded()) {
				Debug.Log ("found ground");
				rigid.AddForce (new Vector2 (0, jump), ForceMode2D.Force);
			} else {
				Debug.Log ("No ground found");}
		}
	}
		
	private bool isGrounded()
	{
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 3f;
		Debug.DrawRay(position, direction, Color.green);
		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
		if (hit.collider != null) {
			return true;
		}

		return false;
	}

	
	public void GlimmerPlay()
	{
		
		sparkles.Play();
	}
	public void GlimmerPause()
	{
		
		sparkles.Pause();
	}
	public void damaged (bool dead){
		if (!dead)
		KnightAnimator.SetTrigger ("Damaged");
		else KnightAnimator.SetBool("Dead", true);

		
	}
	public bool isVulnerable ()
	{
		return (!(Input.GetAxisRaw ("Vertical") < 0f)||iframe);

	}
	public void Swipe()
	{
		
			Vector2 position = transform.position;
		Vector2 direction;
		if (lookLeft)
			direction = Vector2.left;
		else 
			direction = Vector2.right;
		Debug.DrawRay(position, direction, Color.green);
		RaycastHit2D hit = Physics2D.Raycast(position, direction, swingRange);
		if (hit.collider != null) {
			//damage
		}
	}
		
}

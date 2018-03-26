using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour {
	private Rigidbody2D rigid;
	public float speed;
	public float jump; 
	public float swingRange;
	public int facing;
	public bool unin;
	public int hitcount;
	//1=left, 2=right, 3= up


	public LayerMask groundLayer;
	private Animator KnightAnimator;
	public ParticleSystem sparkles;



	// Use this for initialization
	void Start () {
		KnightAnimator =GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
		hitcount = 0;

		//sparkles = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		var axisX = Input.GetAxisRaw ("Horizontal");
		var axisY = Input.GetAxisRaw ("Vertical");
		if (axisX < 0)
			facing = 1;
		else if (axisX > 0)
			facing = 2;
		else
			facing = 3;
		transform.Translate(axisX/4, 0, 0);
	

		KnightAnimator.SetFloat ("PhaseV", axisY);
		KnightAnimator.SetFloat ("Phase", axisX);

		if (Input.GetButtonDown("Fire1")||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)) {
			KnightAnimator.SetTrigger ("Attack");
			Swipe ();
			Debug.Log (hitcount); 
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



	public void damaged (bool dead){
		if (!dead)
		KnightAnimator.SetTrigger ("Damaged");
		else KnightAnimator.SetBool("Dead", true);
		}


	public bool isVulnerable ()
	{
		return (!(Input.GetAxisRaw ("Vertical") < 0f));
	}





	public void Swipe()
	{
		Vector2 position = transform.position;
		Vector2 direction;

		switch (facing) {
		case 1:
			direction = Vector2.left;
			break;
		case 2:
			direction = Vector2.right;
			break;
		case 3:
			direction = Vector2.up;
			break;
		default:
			direction = Vector2.up;
			break;
		}
		//Debug.DrawRay(position, direction, Color.green);
		RaycastHit2D hit = Physics2D.Raycast(position, direction, swingRange);
		if (hit.collider != null) {
			//damage
		}
		hitcount++;
	}
}

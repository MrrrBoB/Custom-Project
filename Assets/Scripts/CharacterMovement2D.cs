using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour {
	public float speed = 6f;
	public float jumpSpeed= 8f;
	public float gravity = 20f;
	private int facing;
	public LayerMask groundLayer;
	private Vector3 moveDirection = Vector3.zero;
	private Animator KnightAnimator;
	private Attack_Melee attack;
	public Transform GroundCheck;
	private Rigidbody2D rigid;

	// Use this for initialization
	void Awake() {
		KnightAnimator =GetComponent<Animator> ();
		attack = GetComponent<Attack_Melee> ();
		rigid = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		//see if grounded

		//see if blocking
		KnightAnimator.SetBool("Blocking", Input.GetMouseButton(1));
		//which direction knight is moving
		var axisX = Input.GetAxisRaw ("Horizontal");
		if (axisX != 0) {
			KnightAnimator.SetBool ("Moving", true);
			if (axisX < 0)
				facing = -1;
			else if (axisX > 0)
				facing = 1;
			}

		else if (Input.GetAxisRaw ("Vertical") == 1)
			facing = 0;
		else
			KnightAnimator.SetBool ("Moving", false);
		
		KnightAnimator.SetInteger ("FacingD", facing);

		//Moving the controller

			moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed / 10;
		transform.Translate (moveDirection);
		//attack-refers to attack mele
		if (Input.GetButtonDown("Fire1")) {
			attack.Swipe (facing);

		}
	}
	public void FixedUpdate()
	{
		
		if (Input.GetButton ("Jump")&&isGrounded())
				rigid.AddForce (new Vector2 (0, jumpSpeed*100), ForceMode2D.Force);
		
	}

	private bool isGrounded()
	{
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 2.25f;
		RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
		if (hit.collider != null) {
			return true;

		}
		return false;
	}

}
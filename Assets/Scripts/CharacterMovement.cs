using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	public float speed = 6f;
	public float jumpSpeed= 8f;
	public float gravity = 20f;
	private int facing;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	private Animator KnightAnimator;
	private Attack_Melee attack;
	 
	// Use this for initialization
	void Awake() {
		controller= GetComponent<CharacterController> ();
		KnightAnimator =GetComponent<Animator> ();
		attack = GetComponent<Attack_Melee> ();
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
		if (controller.isGrounded) {
			moveDirection = new Vector2(Input.GetAxisRaw ("Horizontal"), 0);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed/10;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed/10;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection);

		//attack-refers to attack mele
		if (Input.GetButtonDown("Fire1")) {
			attack.Swipe (facing);
			 
		}
	}

}

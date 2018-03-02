using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour {
	private Rigidbody2D rigid;
	public float speed;
	public bool dead = false;
	Animator KnightAnimator;
	bool hurting=false;
	bool swinging=false;
	public float directionH;
	const int STATE_IDLE=0;
	const int STATE_WALK_RIGHT=1;
	const int STATE_WALK_LEFT=2;
	const int STATE_SWINGING = 3;
	const int STATE_BLOCKING=4;
	public int CurrentAnimationState= STATE_IDLE;
	// Use this for initialization
	void Start () {
		KnightAnimator =GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rigid.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * speed, 0), ForceMode2D.Force);
		directionH = Input.GetAxis ("Horizontal");
		if (directionH < 0) {
			changeState (STATE_WALK_LEFT);
		} else if (directionH > 0) {
			changeState (STATE_WALK_RIGHT);
		} else
			changeState (STATE_IDLE);
	}
	void changeState(int State){

		if (CurrentAnimationState == State)
			return;

		switch (State) {

		case STATE_IDLE:
			KnightAnimator.SetInteger ("State", STATE_IDLE);
			break;

		case STATE_WALK_RIGHT:
			KnightAnimator.SetInteger ("State", STATE_WALK_RIGHT);
			break;

		case STATE_WALK_LEFT:
			KnightAnimator.SetInteger ("State", STATE_WALK_LEFT);
			break;

		case STATE_SWINGING:
			KnightAnimator.SetInteger ("State", STATE_SWINGING);
			break;

		case STATE_BLOCKING:
			KnightAnimator.SetInteger ("State", STATE_BLOCKING);
			break;

		}

		CurrentAnimationState = State;
	}
}

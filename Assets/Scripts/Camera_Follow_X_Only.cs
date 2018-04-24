using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_X_Only : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<CharacterMovement2D> ().gameObject;
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 ((player.transform.position.x), 0, -10);

	}
}

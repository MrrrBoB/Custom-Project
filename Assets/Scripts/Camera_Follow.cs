using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		

	}
	public void OnLevelWasLoaded (int level)
	{
		if (level == 1) {
			player = FindObjectOfType<CharacterMovement2D> ().gameObject;
			offset = transform.position - player.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null)
			transform.position = player.transform.position;

	}
}

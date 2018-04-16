using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour {
	public GameManager manager;
	// Use this for initialization
	void Start () {
		manager = FindObjectOfType<GameManager>().GetComponent<GameManager> ();
	}

	// Update is called once per frame
	private void OnTriggerEnter2D ()
	{
		Debug.Log("fell in pit");

	}
}

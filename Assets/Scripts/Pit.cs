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
	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("fell in pit");
			manager.LoadLevel ("GameOver");
		}
	}
}

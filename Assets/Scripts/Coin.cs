using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public int value;
	public ParticleSystem sparkle;


	private void OnTriggerEnter2D() 
	{
		FindObjectOfType<GameManager> ().addCoin (value);
		Explode ();

	}
	private void Explode() {
		sparkle = GetComponent<ParticleSystem> ();
			sparkle.Play();
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		Destroy(gameObject, sparkle.duration);
	}
}

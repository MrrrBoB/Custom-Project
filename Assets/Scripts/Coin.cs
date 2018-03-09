using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public int value;
	public ParticleSystem sparkle;


	private void OnCollisionEnter2D() 
	{
		FindObjectOfType<GameManager> ().addCoin (value);
		Explode ();

	}
	private void Explode() {
		sparkle = GetComponent<ParticleSystem> ();
			sparkle.Play();
		Destroy (gameObject.GetComponent <CircleCollider2D>());
		Destroy(gameObject, sparkle.duration);
	}
}

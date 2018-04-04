using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public int value;

	public ParticleSystem effect;

	private void OnTriggerEnter2D() 
	{
		FindObjectOfType<GameManager> ().addCoin (value);
		Explode ();

	}


	private void Explode() {
		ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}

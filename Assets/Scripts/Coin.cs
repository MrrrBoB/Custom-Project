using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public int value;
	public enum Tier {Gold, Silver, Bronze};
	public Tier worth;
	public ParticleSystem effect;
	public Animator[] coinAnim = new Animator[3];
	public void Start ()
	{
		worth = (Tier)Random.Range (0, 3);
		switch (worth) {
		case Tier.Gold:
			value = 100;
			break;
		case Tier.Silver:
			value = 25;
			break;
		case Tier.Bronze:
			value = 10;
			break;
		default:
			value = 0;
			break;
		}
	}

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

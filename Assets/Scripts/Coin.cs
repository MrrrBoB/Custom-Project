﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public int value;
	private Color gld= new Color(1f, .75f, 0f ,1f);
	private Color brz= new Color (.75f, .5f, 0f, 1f);
	private Color slv = new Color (1f, 1f, 1f, 1f);
	public SpriteRenderer rend;
	public enum Tier {Gold, Silver, Bronze};
	public Tier worth;
	public ParticleSystem effect;
	public bool random;
	public Animator[] coinAnim = new Animator[3];
	public AudioClip kaching;
	public void Start ()
	{
		rend = GetComponent<SpriteRenderer> ();
		if(random)
		worth = (Tier)Random.Range (0, 3);
		switch (worth) {
		case Tier.Gold:
			value = 100;
			rend.color = gld;
			break;
		case Tier.Silver:
			value = 25;
			rend.color = slv;
			break;
		case Tier.Bronze:
			value = 10;
			rend.color = brz;
			break;
		default:
			value = 0;
			break;
		}
	}

	public void OnTriggerEnter2D(Collider2D obj) 
	{
		if (obj.gameObject.tag == "Player") {
			FindObjectOfType<GameManager> ().AddCoins (value);
			Explode ();
		}

	}


	private void Explode() {
		AudioSource.PlayClipAtPoint (kaching, transform.position);
		ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}

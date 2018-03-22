using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float timerf;
	public int damageStr;
	public ParticleSystem effect;

	// Use this for initialization
	void Start () {
		timerf = 0;

	}
	
	// Update is called once per frame

	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("Hit!");
			FindObjectOfType< GameManager> ().takeHit (damageStr);
		}
			ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
			Destroy (gameObject);
		
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	
	public int damageStr;
	public ParticleSystem effect;
	public ParticleSystem effectFloor;

	// Use this for initialization

	
	// Update is called once per frame

	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("Hit!");
			FindObjectOfType< GameManager> ().takeHit (damageStr, obj.gameObject);
			obj.gameObject.GetComponent<Health> ().ChangeHealth (damageStr * -1);
		}
		if (obj.gameObject.tag == "Ground") {
			ParticleSystem burst = Instantiate (effectFloor, transform.position, Quaternion.identity);
		} else {
			
			ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
		}
			Destroy (gameObject);
		
	}

}

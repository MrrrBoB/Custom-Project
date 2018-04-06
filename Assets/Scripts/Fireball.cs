using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float lifespan;
	public int damageStr;
	public ParticleSystem effect;
	public ParticleSystem effectFloor;

	// Use this for initialization
	public void Start()
	{
		Destroy (gameObject, lifespan);
	}
	
	// Update is called once per frame

	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("Hit!");

			obj.gameObject.GetComponent<Health> ().ChangeHealth (damageStr * -1);
		}
		if (obj.gameObject.tag == "ground") {
			ParticleSystem burst = Instantiate (effectFloor, transform.position, Quaternion.identity);
		} else {
			
			ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
		}
			Destroy (gameObject);
		
	}

}

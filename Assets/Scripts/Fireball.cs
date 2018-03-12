using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	public float timerf;

	// Use this for initialization
	void Start () {
		timerf = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timerf += Time.deltaTime;
		if (timerf >= 2) {
			Destroy (gameObject);}
	}
}

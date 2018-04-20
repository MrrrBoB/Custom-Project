using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PE_toggle : MonoBehaviour {
	
	private ParticleSystem ps;


	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		ps.enableEmission = (Input.GetMouseButton(1));
	}

}

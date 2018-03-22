using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTester : MonoBehaviour {
	private HealthBarController healthBar;
	// Use this for initialization
	void Start () {
		healthBar = GameObject.Find ("Health Bar").GetComponent<HealthBarController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

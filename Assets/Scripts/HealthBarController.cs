using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
	public Slider healthBar;
	public int currentHP=100;
	// Use this for initialization
	void Start () {
		healthBar = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = FindObjectOfType<GameManager>().health;
	}

}

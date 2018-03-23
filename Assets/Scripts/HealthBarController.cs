using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarController : MonoBehaviour {
	public Slider healthBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//healthBar.value = GameObject.FindObjectOfType<GameManager> ().Health;
	}
	public void changeHealth (int damage)
	{healthBar.value -= damage;}
}

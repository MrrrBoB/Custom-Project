using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {
	public float timer;
	public float spawnTimer;

	// Use this for initialization
	void Start () {
		timer = 0f;
		spawnTimer = 3f;
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		print (timer);
		if (timer >= spawnTimer) {
			Instantiate (FindObjectOfType<Fireball>(), new Vector2 (0, 1),Quaternion.identity);
			timer = 0f;

		}
	
	}
}

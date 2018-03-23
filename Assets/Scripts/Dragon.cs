using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {
	public float timer;
	public float spawnTimer;
	public GameObject [] prefabs = new GameObject[3];

	// Use this for initialization
	void Start () {
		timer = 0f;
		spawnTimer = 3f;


	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//print (timer);
		if (timer >= spawnTimer) {
			Instantiate (prefabs[Random.Range(0, 3)], new Vector2 (Random.Range(-13,13), 8),Quaternion.identity);
			timer = 0f;

		}
	
	}
}

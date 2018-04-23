using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {
	public float timer;
	public float spawnTimer;
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		//print (timer);
		if (timer >= spawnTimer) {
			Instantiate (prefab, transform.position, Quaternion.identity);
			timer = 0f;
		}
	}
}

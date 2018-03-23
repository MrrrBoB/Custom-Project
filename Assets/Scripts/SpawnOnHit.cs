using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnHit : MonoBehaviour {
	public GameObject prefab;
	public int height;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "ground")
		Instantiate (prefab, new Vector2(gameObject.transform.position.x, height),Quaternion.identity);
	}
}

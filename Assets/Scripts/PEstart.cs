using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEstart : MonoBehaviour {
	private void Start()
	{
		
		Destroy (gameObject, GetComponent<ParticleSystem>().duration);
	}
	

}

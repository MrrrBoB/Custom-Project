using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
	public Animator spikeAnim;
	public Collider2D box;
	public int damage;
	// Use this for initialization
	void Start () {
		spikeAnim = GetComponent<Animator> ();
		StartCoroutine (Stab ());
		box = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private IEnumerator Stab(){
		while (true) {
			spikeAnim.SetInteger ("Stage", 1);
			yield return new WaitForSeconds (4f);
			spikeAnim.SetInteger ("Stage", 2);
			box.enabled = false;
			yield return new WaitForSeconds (.3f);
			spikeAnim.SetInteger ("Stage", 3);
			yield return new WaitForSeconds (4f);
			spikeAnim.SetInteger ("Stage", 0);
			box.enabled = true;
			yield return new WaitForSeconds (.3f);
		}
	}
	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("You stepped on spikes");
			obj.gameObject.GetComponent<Health> ().ChangeHealth (damage * -1);
		}
	}
}

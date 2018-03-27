using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePuddle : MonoBehaviour {
	public int damageStr;
	public float lifetime;
	private Animator puddleAnim;
	// Use this for initialization
	void Start () {
		puddleAnim = GetComponent<Animator> ();
		StartCoroutine (DelayedAnimation ());

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("You stepped in fire");
			FindObjectOfType< GameManager> ().takeHit (damageStr);
		}
	}
	private IEnumerator DelayedAnimation(){
		
		puddleAnim.SetInteger ("Stage", 1);
		yield return new WaitForSeconds (2.667f);
		puddleAnim.SetInteger ("Stage", 2);
		yield return new WaitForSeconds (.667f);
		Destroy (gameObject);

	}
}

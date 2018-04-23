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
		StartCoroutine (FizzleOut ());

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	public void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "Player") {
			Debug.Log ("You stepped in fire");
			obj.gameObject.GetComponent<Health> ().ChangeHealth (damageStr * -1);
		}
	}
	private IEnumerator FizzleOut(){
		
		puddleAnim.SetInteger ("Stage", 1);
		yield return new WaitForSeconds (2.667f);
		puddleAnim.SetInteger ("Stage", 2);
		yield return new WaitForSeconds (.667f);
		Destroy (gameObject);

	}
}

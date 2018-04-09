using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public Animator animV;
	public int HP;
	public UIManager UIM;
	public void Start()
	{
		animV = GetComponent<Animator> ();
		UIM = FindObjectOfType<UIManager> ().GetComponent<UIManager> ();
	}






	public void ChangeHealth(int value)
	{HP += value;
		if (value <= 0) {
			if (HP <= 0) {
				Die ();
			} else
				animV.SetTrigger ("Damaged");
		}
		UIM.changeHealth (value*-1);
			
	}
	public void Die ()
	{Destroy (gameObject);}
}

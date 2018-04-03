using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public Animator animV;
	public int HP;
	public void Start()
	{
		animV = GetComponent<Animator> ();
	}






	public void ChangeHealth(int value)
	{HP += value;
		if (HP <= 0) {
			Die ();
		} else
			animV.SetTrigger ("Damaged");
		FindObjectOfType<HealthBarController> ().changeHealth (value*-1);
			
	}
	public void Die ()
	{Destroy (gameObject);}
}

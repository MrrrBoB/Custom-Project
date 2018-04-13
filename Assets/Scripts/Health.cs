using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Animator animV;
	public int HP;
	public ParticleSystem effect;
	public Slider healthBar;
	public void Start()
	{
		animV = GetComponent<Animator> ();
		if (healthBar!=null)
		healthBar.maxValue = HP;

	}






	public void ChangeHealth(int value)
	{HP += value;
		if (value <= 0) {
			Whack ();
			if (HP <= 0 && !(gameObject.tag == "Player")) {
				Die ();
			} else 
			{ 
				if(animV!=null)
				animV.SetTrigger ("Damaged");
			}
		}
		if (healthBar!=null)
		changeHealthBar (value*-1);
			
	}
	public void Die ()
	{Destroy (gameObject);}

	public void Whack()
	{
		ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
	}
	public void changeHealthBar (int damage)
	{healthBar.value -= damage;
		if (gameObject.tag==("Player")&&healthBar.value <= 0) {
			FindObjectOfType<GameManager> ().GetComponent<GameManager> ().LoadLevel ("GameOver");
		}
	}
}

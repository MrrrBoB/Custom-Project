using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Animator animV;
	public int HP;
	private int maxHP;
	public ParticleSystem effect;
	public Slider hpBar;
	public bool invulnerable;
	public AudioClip dead;
	public AudioClip ouch;
	public void Start()
	{
		animV = GetComponent<Animator> ();
		if (hpBar != null) {
			hpBar.maxValue = HP;
			hpBar.value = HP;
			maxHP = HP;
		}
	}



	public void ChangeHealth(int value)
	{
		if (!invulnerable) {
			//Only pertains to the player
			if (this.gameObject.tag == "Player") {
				FindObjectOfType<GameManager> ().changeHP (value);
			} else {
				HP += value;
				//check if dead
				if (HP <= 0) {
					if (dead != null)
						AudioSource.PlayClipAtPoint (dead, transform.position);
					Die ();
			
					//if not dead
				}
				//pertains to anyone
			}
			if (hpBar != null)
				changeHealthBar (value * -1);
			if (value < 0) {
				if (animV != null)
					animV.SetTrigger ("Damaged");
				if (ouch != null&&gameObject.tag!="Player")
					AudioSource.PlayClipAtPoint (ouch, transform.position);
			}
		}
	}



	public void Die ()
	{
		if (GetComponent<Loot> () != null) 
		{
			
			gameObject.GetComponent<Loot> ().dropLoot ();
		}
		Destroy (gameObject);
		}

	public void Whack()
	{
		
		ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
	}
	public void changeHealthBar (int damage)
	{
		hpBar.value -= damage;
		if (gameObject.tag == ("Player") && hpBar.value <= 0) {
			print ("youlost");
			hpBar.value = maxHP;
		}

	}

}

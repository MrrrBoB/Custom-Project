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
		if (gameObject.tag == "Player") {
			hpBar = FindObjectOfType<GameManager> ().GetComponent<ScoreHolder> ().healthBar;
		}
		if (hpBar!=null)
		hpBar.maxValue = HP;
		maxHP = HP;

	}






	public void ChangeHealth(int value)
	{if (!invulnerable) {
			HP += value;
			if (value < 0) {
				Whack ();
				if (HP <= 0 && !(gameObject.tag == "Player")) {
					if (dead!=null)
						AudioSource.PlayClipAtPoint (dead, transform.position);
					Die ();
				} else if (HP <= 0 && (gameObject.tag == "Player")) {
					AudioSource.PlayClipAtPoint (dead, transform.position);
					StartCoroutine (DeathDelay ());
				}
				else
				{ 
					if (animV != null)
						animV.SetTrigger ("Damaged");
					if (ouch!=null)
					AudioSource.PlayClipAtPoint (ouch, transform.position);
				
						
				}
			}
			if (hpBar != null)
				changeHealthBar (value * -1);
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
	private IEnumerator DeathDelay()
	{
		animV.SetTrigger ("Dead");
		yield return new WaitForSeconds (1.333f);
		FindObjectOfType<GameManager> ().GetComponent<GameManager> ().changeLives (-1);
		HP = maxHP;
		transform.position = new Vector3 (0, 0, 0);
	}
}

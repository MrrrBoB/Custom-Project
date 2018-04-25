using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Animator animV;
	public int HP;
	private int maxHP;
	public ParticleSystem effect;
	public Slider healthBar;
	public bool invulnerable;
	public GameObject spawn;
	public AudioClip dead;
	public AudioClip ouch;
	public void Start()
	{
		animV = GetComponent<Animator> ();
		if (healthBar!=null)
		healthBar.maxValue = HP;
		maxHP = HP;
		spawn = GameObject.Find ("SpawnPoint");
		if (gameObject.tag == "Player") {
		}
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
			if (healthBar != null)
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
		healthBar.value -= damage;
		if (gameObject.tag == ("Player") && healthBar.value <= 0) {
			print ("youlost");
			healthBar.value = maxHP;
		}

	}
	private IEnumerator DeathDelay()
	{
		animV.SetTrigger ("Dead");
		yield return new WaitForSeconds (1.333f);
		FindObjectOfType<GameManager> ().GetComponent<GameManager> ().changeLives (-1);
		HP = maxHP;
		transform.position = GameObject.Find("SpawnPoint").transform.position;
	}
}

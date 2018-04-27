using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	public enum Power {HP, DMG, INV, CHK, DFL};
	public Power powerUpType;
	public SpriteRenderer pic;
	public AudioClip[] sounds=new AudioClip[5];
	public Sprite [] images= new Sprite[5];
	public ParticleSystem effect;
	public int value;
	public GameObject player;
	public bool random;
	public void Start(){
		player = FindObjectOfType<CharacterMovement2D>().gameObject;
		pic = GetComponent<SpriteRenderer> ();
		if (random)
		powerUpType = (Power)Random.Range (0, 4);
		switch (powerUpType) {
		case Power.HP:
			pic.sprite = images [0];
			break;
		case Power.DMG:
			pic.sprite = images [1];
			break;
		case Power.INV:
			pic.sprite = images [2];
			break;
		case Power.CHK:
			pic.sprite = images [3];
			break;
		default:
			pic.sprite = images [4];
			break;
		}

	}

	private void OnCollisionEnter2D(Collision2D obj) 
	{
		if (obj.gameObject.tag == "Player") {
			switch (powerUpType) {
			case Power.HP:
				player.GetComponent<Health> ().ChangeHealth (value);
				AudioSource.PlayClipAtPoint (sounds[0], transform.position);
				break;
			case Power.DMG:
				player.GetComponent<CharacterMovement2D> ().DamageBoost ();
				AudioSource.PlayClipAtPoint (sounds[1], transform.position);
				break;
			case Power.INV:
				player.GetComponent<CharacterMovement2D> ().invincible ();
				AudioSource.PlayClipAtPoint (sounds[2], transform.position);
				break;
			case Power.CHK:
				FindObjectOfType<GameManager> ().changeLives(1);
				AudioSource.PlayClipAtPoint (sounds[3], transform.position);
				break;
			default:
				pic.sprite = images [4];
				AudioSource.PlayClipAtPoint (sounds[4], transform.position);
				break;
			}

			PickUp ();
		}

	}
	private void PickUp() {
		ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}


}

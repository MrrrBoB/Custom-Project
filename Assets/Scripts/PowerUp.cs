using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	public enum Power {HP, DMG, INV, CHK, DFL};
	public Power powerUpType;
	public SpriteRenderer pic;
	public Sprite [] images= new Sprite[5];
	public ParticleSystem effect;
	public int value;
	public GameObject manager;
	public void Start(){
		pic = GetComponent<SpriteRenderer> ();
		manager = FindObjectOfType<GameManager> ().gameObject;
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
	public void Update()
	{
		
	}
	private void OnTriggerEnter2D() 
	{
		switch (powerUpType) {
		case Power.HP:
			manager.GetComponent<GameManager> ().health += value;
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

		PickUp ();


	}
	private void PickUp() {
		ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}


}

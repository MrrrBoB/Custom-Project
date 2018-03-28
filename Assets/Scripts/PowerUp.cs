using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	public enum Power {HP, DMG, INV, CHK, DFL, CN};
	public Power powerUpType;
	public SpriteRenderer pic;
	public Sprite [] images;
	public ParticleSystem effect;

	public void Start(){
		pic = GetComponent<SpriteRenderer> ();
		images = new Sprite[6];
	}
	public void Update()
	{
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
		case Power.CN:
			pic.sprite = images [4];
			break;
		default:
			pic.sprite = images [5];
			break;
		}
	}
	private void OnTriggerEnter2D() 
	{
		
		PickUp ();

	}
	private void PickUp() {
		ParticleSystem burst = Instantiate (effect, transform.position, Quaternion.identity);




		Destroy(gameObject);
	}

}

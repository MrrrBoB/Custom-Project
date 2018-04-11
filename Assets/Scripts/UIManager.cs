using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
	public Text coinCounter;
	public UIManager instance = null;
	public Slider healthBar;



	// Use this for initialization





	void Start () {
		//If instance is empty, create instance
		if (instance == null)
			instance = this;
		//If instance is not *this* then destroy it
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddCoins(int count)
	{
		coinCounter.text = count.ToString();
	}
	public void changeHealth (int damage)
	{healthBar.value -= damage;
		if (healthBar.value <= 0) {
			FindObjectOfType<GameManager> ().GetComponent<GameManager> ().LoadLevel ("GameOver");
		}
		}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public static GameManager instance = null;
	public int coinCount = 0;
	public int health;
	public GameObject player;
	public bool dead;
	public int lives;
	public UIManager UIM;



	void Awake ()//singleton
	{
		//If instance is empty, create instance
		if (instance == null)
			instance = this;
		//If instance is not *this* then destroy it
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		player = FindObjectOfType<CharacterMovement2D> ().gameObject;
		UIM = FindObjectOfType<UIManager> ().GetComponent<UIManager> ();
		UIM.changeLives (lives);
	}

	/*public void CCursor ()
	{
		if (SceneManager.GetActiveScene ().buildIndex == 2 || SceneManager.GetActiveScene ().buildIndex == 3 || SceneManager.GetActiveScene ().buildIndex == 4)
			Cursor.visible = false;
		else
			Cursor.visible = true;
	}*/
	public void addCoin (int value)
	{
		coinCount += value;
		print ("Coins: "+coinCount);
		UIM.AddCoins (coinCount);
	}
	public void changeLives(int value)
	{
		lives += value;
		UIM.changeLives (lives);
		if (lives <= 0) {
			LoadLevel ("GameOver");
		}
	}
	//fireball hits player


	public void LoadLevel(string Level)
	{
		
		SceneManager.LoadScene (Level);

	}


	public void LoadNextLevel(){
		
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);

	}
	public void QuitGame(){
		Debug.Log ("Quit Game");
		Application.Quit (); 
	}


}

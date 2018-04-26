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
	public int lifeCount;
	public ScoreHolder hold;



	void Awake ()//singleton
	{
		//If instance is empty, create instance
		if (instance == null)
			instance = this;
		//If instance is not *this* then destroy it
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);




		hold = FindObjectOfType<ScoreHolder> ();

	}
	public void OnLevelWasLoaded (int level)
	{

		if ( level >= 1&&level<=4) {
			player = FindObjectOfType<CharacterMovement2D> ().gameObject;
			if (level == 4)
				player.GetComponent<Animator> ().SetBool ("Victory", true);
			else
				player.GetComponent<Animator> ().SetBool ("Victory", false);
		}


	}
	/*public void CCursor ()
	{
		if (SceneManager.GetActiveScene ().buildIndex == 2 || SceneManager.GetActiveScene ().buildIndex == 3 || SceneManager.GetActiveScene ().buildIndex == 4)
			Cursor.visible = false;
		else
			Cursor.visible = true;
	}*/




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
	public void changeHP(int value)
	{
		hold.incrementHP (value);
	}
	public void AddCoins(int count)
	{
		//	coinCounter.text = count.ToString();
		hold.IncrementScore (count);
	}
	public void changeLives(int value)
	{
		hold.IncrementLives (value);
		Debug.Log ("reset");
	}


}

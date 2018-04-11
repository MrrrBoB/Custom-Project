using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	public static MenuManager instance = null;
	// Use this for initialization
	void Awake () {
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

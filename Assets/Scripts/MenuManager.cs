﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
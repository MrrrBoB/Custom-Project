﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
//	public Text coinCounter;
	public Text lifeCounter;
	public ScoreHolder hold;
	public UIManager instance = null;




	// Use this for initialization





	void Start () {
		//If instance is empty, create instance
		if (instance == null)
			instance = this;
		//If instance is not *this* then destroy it
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		hold = FindObjectOfType<ScoreHolder> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddCoins(int count)
	{
	//	coinCounter.text = count.ToString();
		hold.IncrementScore (count);
	}
	public void changeLives(int value)
	{
		lifeCounter.text = value.ToString ();
	}

}

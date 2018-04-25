﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHolder : MonoBehaviour {
	public static ScoreHolder instance = null;
	public Text cCount;
	public Text lCount;
	public Score score;

	// Use this for initialization
	void Start () {
		//If instance is empty, create instance
		if (instance == null)
			instance = this;
		//If instance is not *this* then destroy it
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		lCount.text = score.lives.ToString ();
	}
	public void OnLevelWasLoaded (int level)
	{

		if (level == 1) {
			cCount.text = "0";
			lCount.text = "3";

		}

	}

	// Update is called once per frame
	void Update () {
		
	}
	public void IncrementScore(int value)
	{
		score.coinCount += value;
		cCount.text = score.coinCount.ToString ();
	}
	public void IncrementLives(int value)
	{
		score.lives += value;
		lCount.text = score.lives.ToString ();
		if (score.lives <= 0)
			FindObjectOfType<GameManager> ().LoadLevel ("GameOver");
	}
}

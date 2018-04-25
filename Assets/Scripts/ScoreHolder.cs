using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHolder : MonoBehaviour {
	public static ScoreHolder instance = null;
	public Text scoreBoard;
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void IncrementScore(int value)
	{
		score.amount += value;
		scoreBoard.text = score.amount.ToString ();
	}
}

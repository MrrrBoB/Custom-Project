using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Score : ScriptableObject {

	// Use this for initialization
	public int coinCount;
	public int lives;
	public int playerHealth;
	public void ResetScore()
	{
		coinCount = 0;
		lives = 3;
		playerHealth = 100;
	}
}

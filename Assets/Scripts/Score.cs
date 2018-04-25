using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Score : ScriptableObject {

	// Use this for initialization
	public int amount;
	public void ResetScore()
	{
		amount = 0;
	}
}

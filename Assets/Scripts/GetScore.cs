using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetScore : MonoBehaviour {
	public Text scoreBoard;
	public Score score;

	void Start ()
	{
		scoreBoard.text = score.amount.ToString ();
	}
}

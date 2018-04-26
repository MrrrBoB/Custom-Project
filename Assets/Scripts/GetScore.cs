using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetScore : MonoBehaviour {
	public Text cCount;
	public Text lCount;
	public Slider HealthBar;
	public Score score;

	void Start ()
	{
		cCount.text = score.coinCount.ToString ();
		lCount.text = score.lives.ToString ();
		HealthBar.value = 100;
	}
}

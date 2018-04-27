using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreHolder : MonoBehaviour {
	public static ScoreHolder instance = null;
	public Text cCount;
	public Text lCount;
	public Slider healthBar;
	public Score score;
	public GameObject player;
	public AudioClip dead;
	public AudioClip ouch;

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
				healthBar.value=healthBar.maxValue;
			}
		if (level >= 1) {
			player = FindObjectOfType<CharacterMovement2D> ().gameObject;
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
	public void incrementHP(int value)
		{
		score.playerHealth += value;
		if (value < 0) {
			if (score.playerHealth <= 0) {
				score.playerHealth = 0;
				StartCoroutine (DeathDelay ());
				IncrementLives (-1);
			}
			else 
				AudioSource.PlayClipAtPoint (ouch, player.transform.position);
		}
			changeHealthBar (value);
		if (score.playerHealth > 100)
			score.playerHealth = 100;
		}



	public void changeHealthBar (int damage)
	{
		healthBar.value += damage;
		if  (healthBar.value <= 0)
			
			healthBar.value = healthBar.maxValue;
	}


	private IEnumerator DeathDelay()
	{
		player.GetComponent<Health> ().invulnerable = true;
		player.GetComponent<Animator>().SetTrigger ("Dead");
		AudioSource.PlayClipAtPoint (dead, player.transform.position);
		yield return new WaitForSeconds (1.333f);
		player.transform.position = new Vector3 (0, 0, 0);
		incrementHP (100);
		player.GetComponent<Health> ().invulnerable = false;
	}
}

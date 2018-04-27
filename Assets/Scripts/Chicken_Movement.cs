using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Movement : MonoBehaviour {
	public GameObject prefab;
	public ParticleSystem effect;
	public Animator ChickenAnim;
	public bool goingLeft;
	public int direction;
	public float speed;
	private float holdS;
	public AudioClip cHit;
	// Use this for initialization
	void Start () {
		ChickenAnim = GetComponent<Animator> ();
		holdS = speed;
		StartCoroutine ("routine");
		GetComponent<SpriteRenderer>().flipX=!goingLeft;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.05f*(speed*direction), 0, 0);



}
	public void Turn ()
	{
		goingLeft = !goingLeft;
		direction *= -1;
		speed = holdS;
		GetComponent<SpriteRenderer>().flipX=!goingLeft;
		}

	public void Spit()
	{
		ChickenAnim.SetTrigger ("Spit");
		GameObject mFire = (GameObject)Instantiate (prefab, new Vector2 (gameObject.transform.position.x+direction, gameObject.transform.position.y), Quaternion.Euler (0, (direction+1)*90, 0));
		mFire.GetComponent<Rigidbody2D> ().velocity = new Vector2 (6 * direction, 0);
	}
	private IEnumerator routine()
	{
		while (true) {
			ChickenAnim.SetInteger ("Stage", 1);
			yield return new WaitForSeconds (2);
			Spit ();
			yield return new WaitForSeconds (2);
			Spit ();
			ChickenAnim.SetInteger ("Stage", 0);
			speed = 0;
			yield return new WaitForSeconds (2);
			Spit ();
			yield return new WaitForSeconds (.333f);
			Turn ();

		
		}
	}
}

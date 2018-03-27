using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Movement : MonoBehaviour {
	public GameObject prefab;
	public int health;
	public Animator ChickenAnim;
	public bool goingLeft;
	public int direction;
	public int speed;
	// Use this for initialization
	void Start () {
		ChickenAnim = GetComponent<Animator> ();
		goingLeft = true;
		speed = 1;
		direction = -1;
		StartCoroutine ("routine");

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0.05f*(speed*direction), 0, 0);



}
	public void Turn ()
	{
		goingLeft = !goingLeft;
		direction *= -1;
		speed = 1;
		GetComponent<SpriteRenderer>().flipX=!goingLeft;

	}
	public void Spit()
	{
		ChickenAnim.SetTrigger ("Spit");
		Instantiate (prefab, new Vector2 (gameObject.transform.position.x-2, gameObject.transform.position.y), gameObject.transform.rotation);
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

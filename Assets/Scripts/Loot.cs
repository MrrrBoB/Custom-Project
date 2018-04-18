using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {
	public int tableSize;
	public GameObject[] lootTable= new GameObject[3]; 
	public int[] dropChance= new int[3];
	[Space(20), Header ("Swinging")]
	public int springForce;
	public int springSpread;
	public int minDrop;
	public int maxDrop;
	// Use this for initialization

	public void dropLoot()
	{
		for (int i = 0; i < Random.Range (minDrop, maxDrop); i++) 
		{
			int n = Random.Range (1, 100);
			GameObject item = Instantiate (drop(n), transform.position, Quaternion.identity);
			item.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range (springSpread * -1, springSpread), Random.Range(springForce/2, springForce)));
		}
	}


	public GameObject drop(int value)
	{
		for (int i = 0; i < dropChance.Length; i++) 
		{
			if (value < dropChance [i]) 
			{
				return lootTable[i];
			}
		}
		return lootTable[lootTable.Length-1];
	}
}

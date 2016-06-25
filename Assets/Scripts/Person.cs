using UnityEngine;
using System.Collections;
using System;

public class Person : MonoBehaviour {
	public Sprite rescued;
	public float timeUntilDrown;
	System.Random rand = new System.Random(); 
	public static GameObject gameManager;

	// Use this for initialization
	void Awake () {
		timeUntilDrown = rand.Next (5, 15);
		gameManager = GameObject.Find ("Manager");
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilDrown -= Time.deltaTime;
		if (timeUntilDrown <= 0) {
			if (this.transform.position.y >= 0) {
				gameManager.GetComponent<Manager> ().otherDrownings++;
			} else {
				gameManager.GetComponent<Manager> ().drownings++;
			}
			Destroy (this.gameObject);
		}
	}

	public void rescue()
	{
		this.GetComponent<SpriteRenderer> ().sprite = rescued;
	}
}

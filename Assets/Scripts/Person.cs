using UnityEngine;
using System.Collections;
using System;

public class Person : MonoBehaviour {
	public Sprite[] sprites;
	public Sprite rescueSprite;
	public float timeUntilDrown;
	System.Random rand = new System.Random(); 
	public static GameObject gameManager;
	public bool rescued;
	int spritecount;
	public float timer = 0f, initTime = 0f;


	// Use this for initialization
	void Awake () {
		timeUntilDrown = rand.Next (5, 15);
		gameManager = GameObject.Find ("Manager");
		spritecount = 0;
		timer = initTime;
	}
	
	// Update is called once per frame
	void Update () {
		timeUntilDrown -= Time.deltaTime;
		if (timeUntilDrown <= 0) {
			if (rescued) {
				gameManager.GetComponent<Manager> ().detainees++;
			} else {
				if (this.transform.position.y >= 0) {
					gameManager.GetComponent<Manager> ().otherDrownings++;
				} else {
					gameManager.GetComponent<Manager> ().drownings++;
				}
			}	
			Destroy (this.gameObject);
		}
		if (!rescued) {
			timer -= Time.deltaTime;
			if (timer <= 0f) {
				spritecount++;
				if (spritecount >= 2) {
					spritecount = 0;
				}
				timer = initTime;
			}
			this.GetComponent<SpriteRenderer> ().sprite = sprites [spritecount];	
		}
	}


	public void Rescued()
	{
		this.GetComponent<SpriteRenderer> ().sprite = rescueSprite;
		rescued = true;
	}
}

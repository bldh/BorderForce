using UnityEngine;
using System.Collections;

public class WaterAnimator : MonoBehaviour {

	public Sprite[] sprites;
	int spritecount;
	public float timer = 0f, initTime = 0f;

	// Use this for initialization
	void Start () {
		spritecount = 0;
		timer = initTime;
	}
	
	// Update is called once per frame
	void Update () {
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

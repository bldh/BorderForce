using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class headLine : MonoBehaviour {

	public Sprite[] sprites;
	public int currentLevel;
	// Use this for initialization
	void Start () {
		currentLevel = PlayerPrefs.GetInt ("currentLevel");
		this.GetComponent<SpriteRenderer> ().sprite = sprites [currentLevel-1];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

}

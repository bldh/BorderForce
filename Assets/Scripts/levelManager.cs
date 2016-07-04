using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

	public int currentLevel;
	public GameObject sliders;
	// Use this for initialization

	void Awake () {
		currentLevel = PlayerPrefs.GetInt ("currentLevel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		SceneManager.LoadScene ("Level");
	}

	public void LoadNextLevel(){
		currentLevel++;
		Debug.Log ("Load Level " + currentLevel);
		PlayerPrefs.SetInt ("currentLevel", currentLevel);
		SceneManager.LoadScene("InterLevel");

	}

	public void LoadLevel (string level) {
		Debug.Log ("Load" + level);
		SceneManager.LoadScene (level);
	}
}

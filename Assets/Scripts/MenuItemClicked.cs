using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuItemClicked : MonoBehaviour {

	public int state = 0;

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetInt ("currentLevel", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
		}


	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {

			switch (state) {

			case(1):
				Debug.Log ("Pressed New Game");

				//chuck the code for starting the game here
				Application.LoadLevel("InterLevel");
				break;

			case(2):
				Debug.Log ("Pressed Highscore");
				break;

			case(3):
				Debug.Log ("Pressed Credits");
				SceneManager.LoadScene("Credits");

				break;

			case(4):
				Debug.Log ("Pressed Exit");
				Application.Quit();
				break;

			case(5):
				Debug.Log ("Back from Credits Screen");
				SceneManager.LoadScene ("MainMenu");
				break;

			default:

				Debug.Log ("Nothing");
				break;



			}
		}
	}



}
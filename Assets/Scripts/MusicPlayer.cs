using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	 
	void Awake() {
		Debug.Log ("Music Player Awake : " +GetInstanceID());
		if (instance != null){
			Destroy (gameObject);
			print ("Destroy duplicate music player");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	void Start () {
		Debug.Log ("Music Player Start : " +GetInstanceID());
	}
	
	void Update () {
	
	}
}

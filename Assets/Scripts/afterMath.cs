using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class afterMath : MonoBehaviour {

	public GameObject drowned,otherDrowned,arrivals,returns, opinion;
	public float publicOpinion;
	// Use this for initialization
	void Start () {
//		GameObject drowned = GameObject.Find ("drownings");
//		GameObject otherDrowned= GameObject.Find ("otherDrownings");
//		GameObject arrivals = GameObject.Find ("arrivals");
//		GameObject returns = GameObject.Find ("returns");
		publicOpinion = PlayerPrefs.GetFloat ("opinion");
	}
	
	// Update is called once per frame
	void Update () {
		drowned.GetComponent<Text> ().text = PlayerPrefs.GetInt ("drowned").ToString();
		otherDrowned.GetComponent<Text> ().text = PlayerPrefs.GetInt ("otherDrowned").ToString();
		arrivals.GetComponent<Text> ().text = PlayerPrefs.GetInt ("arrivals").ToString();
		returns.GetComponent<Text> ().text = PlayerPrefs.GetInt ("returns").ToString();
		opinion.GetComponent<Text> ().text = PlayerPrefs.GetFloat ("publicOpinion").ToString();


	}

	public void LoadLevel (string level) {
		Debug.Log ("Load" + level);
		Application.LoadLevel (level);
	}
}

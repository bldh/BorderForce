using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

	public GameObject drowned,otherDrowned,arrivals,returns, opinion;


	void Start () {
//		GameObject drowned = GameObject.Find ("drownings");
//		GameObject otherDrowned= GameObject.Find ("otherDrownings");
//		GameObject arrivals = GameObject.Find ("arrivals");
//		GameObject returns = GameObject.Find ("returns");
	}
	
	void Update () {
		drowned.GetComponent<Text> ().text = PlayerPrefs.GetInt ("drowned").ToString();
		otherDrowned.GetComponent<Text> ().text = PlayerPrefs.GetInt ("otherDrowned").ToString();
		arrivals.GetComponent<Text> ().text = PlayerPrefs.GetInt ("arrivals").ToString();
		returns.GetComponent<Text> ().text = PlayerPrefs.GetInt ("returns").ToString();
		opinion.GetComponent<Text> ().text = PlayerPrefs.GetFloat ("publicOpinion").ToString();


	}
}

using UnityEngine;
using System.Collections;

public class TurnbackCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		Debug.Log ("Trigger Enter");
		if (c.gameObject.name == "IEV"){
			c.SendMessage("Influenced", true);
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		Debug.Log ("Trigger Enter");
		if (c.gameObject.name == "IEV"){
			c.SendMessage("Influenced", false);
		}
	}

}

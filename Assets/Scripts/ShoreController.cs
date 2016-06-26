using UnityEngine;
using System.Collections;

public class ShoreController : MonoBehaviour {

	public static GameObject gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController");
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "IEV") {
			if (this.gameObject.name == "Shore") {
				gameManager.GetComponent<Manager> ().incrArrivals (c.gameObject.GetComponent<BoatController> ().passengers);
				Destroy (c.gameObject);
			}
			if (this.gameObject.name == "Origin") {
				gameManager.GetComponent<Manager> ().incrReturns (c.gameObject.GetComponent<BoatController> ().passengers);
				Destroy (c.gameObject);
			}
		}

	}
}
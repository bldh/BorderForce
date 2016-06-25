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
			gameManager.GetComponent<Manager> ().incrArrivals (c.gameObject.GetComponent<BoatController> ().passengers);
			Destroy (c.gameObject);
		}

	}
}
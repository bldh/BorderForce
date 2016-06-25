using UnityEngine;
using System.Collections;

public class ShoreController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "Illegal Entry Vehicle")
			Destroy(c.gameObject);
	}
}

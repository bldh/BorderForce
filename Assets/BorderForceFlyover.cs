using UnityEngine;
using System.Collections;

public class BorderForceFlyover : MonoBehaviour {

	public float vel;
	public float timer = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = (Vector2)transform.TransformDirection(Vector3.up) * vel;
		timer -= Time.deltaTime;
		if (timer <= 0) {
			Destroy (this.gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;
using System;

public class BoatController : MonoBehaviour {
	public int resolve;
	public int passengers;
	public bool influenced, turnback;
	public float integrity;
	public float vel, time;
	public GameObject goHome;
	public Vector3 startRot;

	private float timeSpawnedAt;

	// Use this for initialization
	void Start () {
		vel = 0.1f;
		resolve = 50;
		turnback = false;
		time = 0f;
		timeSpawnedAt = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad - timeSpawnedAt > integrity) {
			//Destroy (this.gameObject);
		}

		if (Input.GetMouseButton(0)) {
			if (influenced) {
				resolve--;
			}
		}

		if (resolve == 0) {
			turnback = true;
			startRot = this.transform.rotation.eulerAngles;
		}

		if (turnback) {
			Vector3 diff = goHome.transform.position - this.transform.position;
			diff.Normalize ();
			float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;

			Vector3 currentRot = Vector3.Lerp(startRot, new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rot_z-90),time);
			time += Mathf.Clamp (Time.deltaTime * .5f, 0, 1);
			transform.rotation = Quaternion.Euler(currentRot); 

		
		}
		this.GetComponent<Rigidbody2D>().velocity = (Vector2)transform.TransformDirection(Vector3.up) * vel;
	}

	void Reverse(bool value)
	{
		turnback = value;
		startRot = this.transform.rotation.eulerAngles;
	}

	void Influenced(bool influence)
	{
		influenced = influence;
	}
	public void setPassengers(int num)
	{
		passengers = num;
	}
		
}

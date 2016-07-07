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
	public GameObject refugee, person;
	public Vector3 startRot;
	System.Random rand = new System.Random();
	public Sprite[] sprites;
	public int spriteCount;
	public AudioClip breaking;

	private float timeSpawnedAt;

	// Use this for initialization
	void Start () {
		goHome = GameObject.Find ("Home");
		vel = -0.5f;
		resolve = 50;
		turnback = false;
		time = 0f;
		timeSpawnedAt = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		integrity -= Time.deltaTime;
		if (integrity <= 0) {
			sinkBoat ();
		}

		if (Input.GetMouseButton(0)) {
			if (influenced) {
				resolve--;
			}
		}

		if (resolve == 0) {
			turnback = true;
			startRot = this.transform.rotation.eulerAngles;
			integrity += rand.Next (5, 15);
		}

		if (turnback) {
			Vector3 diff = goHome.transform.position - this.transform.position;
			diff.Normalize ();
			float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
			Vector3 currentRot = Vector3.Lerp(startRot, new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, rot_z+90),time);
			time += Mathf.Clamp (Time.deltaTime * .5f, 0, 1);
			transform.rotation = Quaternion.Euler(currentRot); 
		}
		this.GetComponent<Rigidbody2D>().velocity = (Vector2)transform.TransformDirection(Vector3.up) * vel;
		drawBoatDamage ();	
	}

	void sinkBoat(){
		//print (Time.timeSinceLevelLoad);
		Vector3 spawnPoint = this.transform.position;
		for (int i = 0; i < passengers; i++){
			Debug.Log ("Person Created");
			Vector3 spawnOffset = new Vector3 (UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range (-1.0f, 1.0f), 0);
			GameObject newRefugee = Instantiate (person, spawnPoint + spawnOffset, Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
			newRefugee.transform.name = "Refugee";
		}
		AudioSource.PlayClipAtPoint (breaking, this.transform.position,0.55f);
		Destroy (this.gameObject);
	}
		
	void drawBoatDamage() {
		if (integrity >= 20f) {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [0];			
		}
		else if (integrity >= 10f) {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [1];	
		}
		else if (integrity >= 0f) {
			this.GetComponent<SpriteRenderer> ().sprite = sprites [2];	
		}
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

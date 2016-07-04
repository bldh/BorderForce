using UnityEngine;
using System.Collections;
using System;

public class LevelController : MonoBehaviour {
	public GameObject boat1,boat2,boat3,boat4,boat5;
	public GameObject[] boat;

	public float timeBetweenSpawnAttempts;
	public int spawnChance, spawnType, maxBoatLevel;
	public float boatIntegrityModifierInit;
	System.Random rand = new System.Random(); 

	private float lastSpawn;
	// Use this for initialization
	void Start () {
		lastSpawn = Time.timeSinceLevelLoad;
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad - lastSpawn > timeBetweenSpawnAttempts) {
			TrySpawn ();
		}
	}

	void TrySpawn()
	{
		print ("Trying Spawn");
		int spawn = rand.Next (0, 100);
		if (spawn < spawnChance) {
			spawnType = rand.Next (0, maxBoatLevel);
			float integrity = rand.Next (-10, 10);
			float boatIntegrityModifier = boatIntegrityModifierInit + integrity;
			float angleModifier = rand.Next (-15, 15);
			int pax = rand.Next (2, 8);
			GameObject g = Instantiate (boat[spawnType], new Vector2 (rand.Next (-9, 9), 4), Quaternion.Euler (new Vector3 (0, 0, 0 + angleModifier))) as GameObject;
			g.transform.name = "IEV";
			g.transform.SetParent (this.transform);
			g.GetComponent<BoatController>().setPassengers(pax);
			g.GetComponent<BoatController>().integrity = boatIntegrityModifier;
			lastSpawn = Time.timeSinceLevelLoad;
		}	
	}
}

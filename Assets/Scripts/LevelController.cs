﻿using UnityEngine;
using System.Collections;
using System;

public class LevelController : MonoBehaviour {
	public GameObject boat1,boat2,boat3,boat4,boat5;

	public float timeBetweenSpawnTries;
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
		if (Time.timeSinceLevelLoad - lastSpawn > timeBetweenSpawnTries)
			TrySpawn ();
	}
	void TrySpawn()
	{
		print ("Trying Spawn");
		int spawn = rand.Next (0, 100);
		if (spawn < spawnChance) {
			spawnType = rand.Next (0, maxBoatLevel);
			float integrity = rand.Next (-10, 10);
			float boatIntegrityModifier = boatIntegrityModifierInit + integrity;
			switch (spawnType) {
			case 0:
				GameObject g = Instantiate (boat1, new Vector2 (rand.Next (-9, 9), 4), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
				g.transform.name = "IEV";
				g.transform.SetParent (this.transform);
				g.GetComponent<BoatController>().setPassengers(5);
				g.GetComponent<BoatController>().integrity = boatIntegrityModifier;
				//Raft Boat
				break;
			case 1:
				GameObject d = Instantiate (boat2, new Vector2(rand.Next (-9, 9),4), Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
				d.transform.name = "IEV";
				d.transform.SetParent (this.transform);
				d.GetComponent<BoatController>().setPassengers(5);
				d.GetComponent<BoatController>().integrity = boatIntegrityModifier;
				//Wreck Boat
				break;
			case 2:
				GameObject t = Instantiate (boat3, new Vector2(rand.Next (-9, 9),4), Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
				t.transform.name = "IEV";
				t.transform.SetParent (this.transform);
				t.GetComponent<BoatController>().setPassengers(5);
				t.GetComponent<BoatController>().integrity = boatIntegrityModifier;
				//Less Wreck Boat
				break;
			case 3:
				GameObject y = Instantiate (boat4, new Vector2(rand.Next (-9, 9),4), Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
				y.transform.name = "IEV";
				y.transform.SetParent (this.transform);
				y.GetComponent<BoatController>().setPassengers(5);
				y.GetComponent<BoatController>().integrity = boatIntegrityModifier;
				//Fishing Boat
				break;
			case 4:
				GameObject u = Instantiate (boat5, new Vector2 (rand.Next (-9, 9), 4), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
				u.transform.name = "IEV";
				u.transform.SetParent (this.transform);
				u.GetComponent<BoatController>().setPassengers(5);
				u.GetComponent<BoatController>().integrity = boatIntegrityModifier;
				//Speed Boat
				break;
			}
			lastSpawn = Time.timeSinceLevelLoad;
		}	
	}
}

using UnityEngine;
using System.Collections;
using System;

public class LevelController : MonoBehaviour {
	public GameObject boat;

	public float timeBetweenSpawnTries;
	public int spawnChance;
	public int maxBoatLevel;
	public float boatIntegrityModifier;
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
		int spawn = rand.Next (0, 100);
		if (spawn < spawnChance) {
			int spawnType = rand.Next (0, maxBoatLevel);
			//int spawnType = 0;
			switch (spawnType) {
			case 0:
				GameObject g = Instantiate (boat, new Vector2 (rand.Next (-9, 9), 6), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
				g.transform.name = "IEV";
				g.transform.SetParent (this.transform);
				g.GetComponent<BoatController>().setPassengers(5);
				//Raft Boat
				break;
			case 1:
				GameObject d = Instantiate (boat, new Vector2(rand.Next (-9, 9),6), Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
				d.transform.name = "IEV";
				d.transform.SetParent (this.transform);
				d.GetComponent<BoatController>().setPassengers(5);
				//Wreck Boat
				break;
			case 2:
				GameObject t = Instantiate (boat, new Vector2(rand.Next (-9, 9),6), Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
				t.transform.name = "IEV";
				t.transform.SetParent (this.transform);
				t.GetComponent<BoatController>().setPassengers(5);
				//Less Wreck Boat
				break;
			case 3:
				GameObject y = Instantiate (boat, new Vector2(rand.Next (-9, 9),6), Quaternion.Euler(new Vector3(0,0,0))) as GameObject;
				y.transform.name = "IEV";
				y.transform.SetParent (this.transform);
				y.GetComponent<BoatController>().setPassengers(5);
				//Fishing Boat
				break;
			case 4:
				GameObject u = Instantiate (boat, new Vector2 (rand.Next (-9, 9), 6), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
				u.transform.name = "IEV";
				u.transform.SetParent (this.transform);
				u.GetComponent<BoatController>().setPassengers(5);
				//Speed Boat
				break;
			}
			lastSpawn = Time.timeSinceLevelLoad;
		}	
	}
}

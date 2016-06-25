using UnityEngine;
using System.Collections;
using System;

public class BoatController : MonoBehaviour {
	public int resolve;
	public int passengers;

	public float integrity;
	public float vel;
	public Vector2 startPos;
	// Use this for initialization
	void Start () {
		this.transform.position = startPos;
		vel = -0.01f;
		resolve = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (resolve <= 0) {
			vel = 0.01f;
		}

		this.transform.position+= new Vector3(0f,vel, 0f);
	}

	void FUCKOFFWEREFULL(float val)
	{
		vel = val;
	}
}

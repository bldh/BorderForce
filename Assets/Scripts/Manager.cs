﻿using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public int drownings = 0;
	public int otherDrownings= 0;

	public int detainees= 0;
	public int returns = 0;
	public int arrivals= 0; 
	public float opinion = 50;

	private int maxInDetention = 10;
	private int maxDrownings = 10;
	private int maxArrivals = 10;

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		opinion = 50;
	}
	
	// Update is called once per frame
	void Update () {
		if(	drownings > maxDrownings){
			//gameOver
		}
		if(arrivals > maxArrivals){
			//gameOver
		}
		if(detainees > maxInDetention){
			//gameOver
		}
	}

	public void incrDrowned(int num)
	{
		drownings += num;
		opinion--;
	}

	public void incrDetention(int num)
	{
		detainees += num;
	}

	public void incrArrivals(int num)
	{
		arrivals += num;
		opinion--;
	}	

	public void incrReturns(int num)
	{
		returns += num;
		opinion = opinion++;
	}
}

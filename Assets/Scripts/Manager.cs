﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	//public Manager instance;
	public int drownings = 0;
	public int otherDrownings= 0;
	public int detainees= 0;
	public int returns = 0;
	public int arrivals= 0;
	public int currentLevel;
	public float opinion = 50;
	public float levelTimer = 60;
	private int maxInDetention = 50;
	private int maxDrownings = 50;
	private int maxArrivals = 50;

	public GameObject rating, levelMan;

	void Awake(){
		rating = GameObject.Find ("rating");
	}

	// Use this for initialization
	void Start () {
		opinion = 50;
		levelTimer = 60;
		levelMan = GameObject.Find("Manager");
		currentLevel = PlayerPrefs.GetInt ("currentLevel");
		if (currentLevel > 1) {
			LoadData ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		levelTimer -= Time.deltaTime;
		if (levelTimer <= 0) {
			if (currentLevel < 6) {
				SaveData ();
				levelMan.GetComponent<levelManager> ().LoadNextLevel ();
			} else {
				gameOver ();
			}
		}
		if(	drownings > maxDrownings){
			gameOver ();
		}
		if(arrivals > maxArrivals){
			gameOver ();
		}
		if(detainees > maxInDetention){
			gameOver ();
		}
		if( opinion <= 35){
			gameOver ();
		}

		rating.GetComponent<Text> ().text = opinion.ToString();
	}

	void updateOpinion ()
	{
		opinion = 50 - ((float)arrivals * .4f) - ((float)drownings * .8f) - ((float)detainees * .2f) + ((float)returns * .15f);
		if (opinion > 99) {
			opinion = 99;
		}
	}

	public void incrDrowned(int num)
	{
		drownings += num;
		updateOpinion ();
	}

	public void incrOtherDrowned(int num)
	{
		otherDrownings += num;
		updateOpinion ();
	}


	public void incrDetention(int num)
	{
		detainees += num;
		updateOpinion ();
	}

	public void incrArrivals(int num)
	{
		arrivals += num;
		updateOpinion ();
	}

	public void incrReturns(int num)
	{
		returns += num;
		updateOpinion ();
	}

	public void gameOver()
	{
		SaveData ();
		Application.LoadLevel ("Aftermath");
	}

	public void LoadData() {
		drownings = PlayerPrefs.GetInt ("drowned");
		otherDrownings = PlayerPrefs.GetInt ("otherDrowned");
		detainees = PlayerPrefs.GetInt ("detainees");
		arrivals = PlayerPrefs.GetInt ("arrivals");
		returns = PlayerPrefs.GetInt ("returns");
		opinion = PlayerPrefs.GetFloat ("publicOpinion");
	}
		
	public void SaveData() {
		PlayerPrefs.SetInt ("drowned", drownings);
		PlayerPrefs.SetInt ("otherDrowned", otherDrownings);
		PlayerPrefs.SetInt ("detainees", detainees);
		PlayerPrefs.SetInt ("arrivals", arrivals);
		PlayerPrefs.SetInt ("returns", returns);
		PlayerPrefs.SetFloat ("publicOpinion", opinion);
	}


}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public Manager instance;
	public int drownings = 0;
	public int otherDrownings= 0;

	public int detainees= 0;
	public int returns = 0;
	public int arrivals= 0; 
	public float opinion = 50;

	private int maxInDetention = 50;
	private int maxDrownings = 50;
	private int maxArrivals = 50;

	public GameObject rating;

	void Awake(){
//		if (instance != null){
//				Destroy (gameObject);
//				print ("Destroy duplicate music player");
//			} else {
//				instance = this;
//				//GameObject.DontDestroyOnLoad(gameObject);
//			}
		rating = GameObject.Find ("rating");
//
	}

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll ();
		opinion = 50;

	}
	
	// Update is called once per frame
	void Update () {
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
		opinion = 50 - ((float)arrivals * .4f) - ((float)drownings * .8f) - ((float)detainees * .2f) + ((float)returns * .3f);
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
		PlayerPrefs.SetInt ("drowned", drownings);
		PlayerPrefs.SetInt ("otherDrowned", otherDrownings);
		PlayerPrefs.SetInt ("detainees", detainees);
		PlayerPrefs.SetInt ("arrivals", arrivals);
		PlayerPrefs.SetInt ("returns", returns);
		PlayerPrefs.SetFloat ("publicOpinion", opinion);

		Application.LoadLevel ("Aftermath");
	}
		


}

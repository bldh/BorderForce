using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public static float mB, fAB, bPB;
	public float mBud, fABud, bPBud;
	private int maxInDetention = 50;
	private int maxDrownings = 50;
	private int maxArrivals = 50;
	public int paxModifier;

	public GameObject[] boat;

	public float timeBetweenSpawnAttempts;
	public int spawnChance, spawnType;
	public float boatIntegrityModifierInit;
	System.Random rand = new System.Random(); 
	private float lastSpawn;

	public GameObject rating, levelMan;

	void Awake(){
		rating = GameObject.Find ("rating");
	}

	// Use this for initialization
	void Start () {
		lastSpawn = Time.timeSinceLevelLoad;
		opinion = 50;
		levelTimer = 60;
		levelMan = GameObject.Find("Manager");
		currentLevel = PlayerPrefs.GetInt ("currentLevel");
		LoadData ();
		bPBud = bPB;
		mBud = mB;
		fABud = fAB;
		paxModifier = (int) (fAB * 5);
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

		if (Time.timeSinceLevelLoad - lastSpawn > (timeBetweenSpawnAttempts)) {
			TrySpawn ();
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

	void TrySpawn() {
		print ("Trying Spawn");
		int spawn = rand.Next (0, 100);
		if (spawn < spawnChance) {
			spawnType = rand.Next (0, boat.Length);
			float integrity = rand.Next (1, 20);
			float boatIntegrityModifier = boatIntegrityModifierInit + (integrity * (1 - mB));
			float angleModifier = rand.Next (-15, 15);
			int pax = (rand.Next (5, 10)) - paxModifier;
			GameObject g = Instantiate (boat[spawnType], new Vector2 (rand.Next (-9, 9), 4), Quaternion.Euler (new Vector3 (0, 0, 0 + angleModifier))) as GameObject;
			g.transform.name = "IEV";
			g.transform.SetParent (this.transform);
			g.GetComponent<BoatController>().setPassengers(pax);
			g.GetComponent<BoatController>().integrity = boatIntegrityModifier;
			lastSpawn = Time.timeSinceLevelLoad;
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
		SceneManager.LoadScene ("Aftermath");
	}

	public void LoadData() {
		if (currentLevel > 1) {
			drownings = PlayerPrefs.GetInt ("drowned");
			otherDrownings = PlayerPrefs.GetInt ("otherDrowned");
			detainees = PlayerPrefs.GetInt ("detainees");
			arrivals = PlayerPrefs.GetInt ("arrivals");
			returns = PlayerPrefs.GetInt ("returns");
			opinion = PlayerPrefs.GetFloat ("publicOpinion");
		}
		mB = PlayerPrefs.GetFloat ("militaryBudget");
		fAB = PlayerPrefs.GetFloat ("foreignAidBudget");
		bPB = PlayerPrefs.GetFloat ("borderPatrolBudget");
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

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sliders : MonoBehaviour {

	public GameObject militaryBudget, foreignAidBudget, borderPatrolBudget;
	public float mB, fAB, bPB, temp; 

	// Use this for initialization
	void Start () {
		militaryBudget = GameObject.Find ("Military");
		foreignAidBudget = GameObject.Find ("Foreign Aid");
		borderPatrolBudget = GameObject.Find ("Border Patrol");
//		mB = 0.33f;
//		fAB = 0.33f;
//		bPB = 0.33f;
	}

	void Awake (){

	}

	void Update () {

		mB = militaryBudget.GetComponent<Slider> ().value;
		fAB = foreignAidBudget.GetComponent<Slider> ().value;
		bPB = borderPatrolBudget.GetComponent<Slider> ().value;
		if (mB > 0.98) { mB = 0.98f; }
		if (mB < 0.01) { mB = 0.01f; }
		if (fAB > 0.98) { fAB = 0.98f; }
		if (fAB < 0.01) { fAB = 0.01f; }
		if (bPB > 0.98) { bPB = 0.98f; }
		if (bPB < 0.01) { bPB = 0.01f; }

		temp = mB + fAB + bPB;
		mB = mB / temp;
		fAB = fAB / temp;
		bPB = bPB / temp;

		militaryBudget.GetComponent<Slider> ().value = mB;
		foreignAidBudget.GetComponent<Slider> ().value = fAB;
		borderPatrolBudget.GetComponent<Slider> ().value = bPB;
	}

	public void SaveData (){
		PlayerPrefs.SetFloat ("militaryBudget", mB);
		PlayerPrefs.SetFloat ("foreignAidBudget", fAB);
		PlayerPrefs.SetFloat ("borderPatrol", bPB);
	}

	public void LoadData () {
		militaryBudget.GetComponent<Slider> ().value = PlayerPrefs.GetFloat ("militaryBudget");
		foreignAidBudget.GetComponent<Slider> ().value = PlayerPrefs.GetFloat ("foreignAidBudget");
		borderPatrolBudget.GetComponent<Slider> ().value = PlayerPrefs.GetFloat ("borderPatrolBudget");
	}

}


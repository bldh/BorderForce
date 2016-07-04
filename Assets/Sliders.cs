using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sliders : MonoBehaviour {

	public GameObject militaryBudget, foreignAidBudget, borderPatrolBudget;
	public float mB, fAB, bPB, mBold, fABold, bPBold, temp, temp2; 

	// Use this for initialization
	void Start () {
		militaryBudget = GameObject.Find ("Military");
		foreignAidBudget = GameObject.Find ("Foreign Aid");
		borderPatrolBudget = GameObject.Find ("Border Patrol");
	}
	
	// Update is called once per frame
	void Update () {
		mBold = mB;
		mB = militaryBudget.GetComponent<Slider> ().value;
		if (mB != mBold) {
			Debug.Log ("militaryBudgetChanged");
			temp = 1 - mB;
			temp2 = fAB / bPB;
			fAB = fAB - temp / temp2;	
		}
		fABold = fAB;
		fAB = foreignAidBudget.GetComponent<Slider> ().value;
		if (fAB != fABold) {
			Debug.Log ("foreignAidBudgetChanged");		
		}
		bPBold = bPB;
		bPB = borderPatrolBudget.GetComponent<Slider> ().value;
		if (bPB != bPBold) {
			Debug.Log ("borderPatrolBudgetChanged");
		}
	}

	public void SaveData (){
		PlayerPrefs.SetFloat ("militaryBudget", mB);
		PlayerPrefs.SetFloat ("foreignAidBudget", fAB);
		PlayerPrefs.SetFloat ("borderPatrol", bPB);
	}
}

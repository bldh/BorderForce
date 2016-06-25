using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {
	public Sprite rescued;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void rescue()
	{
		this.GetComponent<SpriteRenderer> ().sprite = rescued;
	}
}

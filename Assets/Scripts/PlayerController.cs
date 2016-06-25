using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	GameObject cone;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float moveX, moveY;
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");
		this.transform.position = new Vector3 (Mathf.Clamp(moveX + this.transform.position.x,-9f,9f), Mathf.Clamp(moveY + this.transform.position.y,-4f,-0.5f),0);

		if(Input.GetButtonUp("Fire1"))
			{
				this.transform.parent.BroadcastMessage("FUCKOFFWEREFULL", 0.03f);
			}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "IEV")
			c.SendMessage("Reverse", 0.01f);
	}
}

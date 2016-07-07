using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject cone, gameManager, borderForce;
	public float borderForceCountdown;
	public bool sendBorderForce;
	public AudioClip borderForceSFX;
	// Use this for initialization
	void Start () {
		borderForceCountdown = 5;
		gameManager = GameObject.Find ("Manager");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - cone.transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

		if (!Input.GetMouseButton(0)) {
			if (Input.GetKey (KeyCode.W)){
				transform.position = Vector2.MoveTowards (this.transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), 1f * Time.deltaTime);
				transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90); 
			}
			cone.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

			transform.position = new Vector3 (Mathf.Clamp (this.transform.position.x, -9f, 9f), Mathf.Clamp (this.transform.position.y, -4f, -0.5f), 0);
		}
		if(Input.GetButtonDown("Fire1")) {
			if (borderForceCountdown <= 0) {
				this.transform.parent.BroadcastMessage ("Reverse", true);
				borderForceCountdown = 30f - (Manager.bPB * 10);
				sendBorderForce = true;
			}
		}
		if (sendBorderForce) {
			GameObject b = Instantiate (borderForce, new Vector2 (0, -5), Quaternion.Euler (new Vector3 (0, 0, 0))) as GameObject;
			sendBorderForce = false;
			AudioSource.PlayClipAtPoint (borderForceSFX, Camera.main.transform.position);
		}
		borderForceCountdown -= Time.deltaTime;
	
	}


	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "Refugee") {
			c.SendMessage("Rescued");
		}

	}
}

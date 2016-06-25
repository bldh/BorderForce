using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject cone;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		float moveX, moveY;

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
		if(Input.GetButtonDown("Fire1"))
			{
				this.transform.parent.BroadcastMessage("Reverse", true);
			}
	}
}

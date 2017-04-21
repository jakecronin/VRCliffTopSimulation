using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShooter : MonoBehaviour {

	public GameObject player;
	public int speed;
	public float verticalSpeed;

	GameObject prefab;
	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			GameObject projectile = Instantiate (prefab) as GameObject;	//instantiate a projectile
			projectile.transform.position = transform.position + transform.forward;	//set initial position
			Rigidbody rb = projectile.GetComponent<Rigidbody> ();		//grab rigid body component
			Vector3 incline = new Vector3(0,verticalSpeed,0);
			rb.velocity = (player.transform.position - rb.transform.position).normalized * speed + incline;	//set initial velocity
			Destroy (projectile, 10);
		}
	}
}

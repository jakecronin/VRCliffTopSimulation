using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour {

	GameObject prefab;
	public GameObject player;
	public int speed;
	public float verticalSpeed;

	public GameObject controllerLeft;

	//used for haptic feedback
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device device;

	//used for delegate
	private SteamVR_TrackedController controller;



	//public SteamVR_TrackedObject trackedObject;
	//public SteamVR_Controller.Device Controller
	//{
	//	get{ return SteamVR_Controller.Input ((int)trackedObject.index);}
	//}

	//void Awake(){
	//	trackedObject = GetComponent<SteamVR_TrackedObject> ();
	//}

	// Use this for initialization
	void Start () {	
		if (controllerLeft == null) {
			Debug.Log ("controller left is null");
		} else {
			Debug.Log ("controller left not null");
		}
		prefab = Resources.Load ("projectile") as GameObject;
		controller = controllerLeft.GetComponent<SteamVR_TrackedController> ();
		Debug.Log ("Got controller: " + controller.enabled);
		controller.TriggerClicked += TriggerPressed;
		trackedObject = controllerLeft.GetComponent<SteamVR_TrackedObject> ();
	}
	private void TriggerPressed(object sender, ClickedEventArgs e){
		Debug.Log ("Trigger Pressed");
		shootCannon ();
	}

	public void shootCannon(){
		Debug.Log ("Cannon Shot!");

		device = SteamVR_Controller.Input((int)trackedObject.index);
		device.TriggerHapticPulse (900);

		GameObject projectile = Instantiate (prefab) as GameObject;	//instantiate a projectile
		projectile.transform.position = transform.position + transform.forward ;	//set initial position
		Rigidbody rb = projectile.GetComponent<Rigidbody> ();		//grab rigid body component
		Vector3 incline = new Vector3(0,verticalSpeed,0);
		rb.velocity = (player.transform.position - rb.transform.position).normalized * speed + incline;	//set initial velocity
		Destroy (projectile, 5);
	}

	// Update is called once per frame
	//void Update () {
	//	if (controller.GetHairTriggerDown()) {
			
	//	}
	//}
}

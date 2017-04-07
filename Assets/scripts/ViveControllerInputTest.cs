using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour {

	// Use this for initialization
	private SteamVR_TrackedObject trackedObject;
	private SteamVR_Controller.Device Controller
	{
		get{ return SteamVR_Controller.Input ((int)trackedObject.index);}
	}

	void Awake(){
		trackedObject = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetHairTriggerDown ()) {
			Debug.Log (gameObject.name + " Trigger Press ");
		}
	}
}

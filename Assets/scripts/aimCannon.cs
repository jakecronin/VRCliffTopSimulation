using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimCannon : MonoBehaviour {

	public Transform target;
	public Transform foundation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target, foundation.up); 
		//make cannont .front face person
	}
}

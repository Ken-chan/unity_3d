using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autopilot : MonoBehaviour {

	public Rigidbody rb;
	public float startSpeed = 0;
	public float startSpeedUp = 100000;

	void Start () {		
	}
	void FixedUpdate () {

		Vector3 z = new Vector3 (0, 0, 1);
		Vector3 y = new Vector3 (0, 1, 0);
		rb.AddRelativeForce(z*startSpeed);
		rb.AddRelativeForce(y*startSpeedUp);
		//Debug.Log (startSpeedUp);
	}
}

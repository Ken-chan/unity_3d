using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireR : MonoBehaviour {
	public GameObject[] rocket = new GameObject[6];
	public float RocketThrust = 0;
	int iterator = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine(Example());
	}

	IEnumerator Example()
	{
		yield return new WaitForSeconds(1000);
	}

	// Update is called once per frame
	void FixedUpdate () {
		float fireR = Input.GetAxis ("Fire1");
		if (fireR != 0 && iterator < 6) {
			Destroy (rocket [iterator], 10);
			rocket [iterator].transform.parent = null;
			rocket [iterator].transform.GetComponent<Rigidbody> ().isKinematic = false;
			rocket [iterator].transform.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * RocketThrust);
			iterator++;
		}
	}
}

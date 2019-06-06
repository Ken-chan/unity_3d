using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInfo : MonoBehaviour {
	public enum Status { Offline, Host, Client, NetworkHost, NetworkClient };
	public int CurStatus = (int) Status.Offline;
	public string nick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

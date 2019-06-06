using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainNetworkManager : NetworkManager 
{

	InGameNetworkBehaviour inGameNetworkBehaviour;
	public NetworkInfo networkInfo;

	public override void OnStartHost ()
	{
		//Debug.Log ("OnStartHost");
		networkInfo.CurStatus = (int)NetworkInfo.Status.Host;
	}

	public override void OnStartClient (NetworkClient client)
	{
		
		//Debug.Log ("OnStartClient");

	}

	public override void OnClientConnect (NetworkConnection conn)
	{
		//Debug.Log ("OnClientConnect");
		base.OnClientConnect (conn);
	}

	public override void OnClientSceneChanged (NetworkConnection conn)
	{
		Debug.Log ("OnClientScene");
		base.OnClientSceneChanged (conn);
		if (networkInfo.CurStatus != (int)NetworkInfo.Status.Host)
			networkInfo.CurStatus = (int)NetworkInfo.Status.Client;
		GameObject[] goArr = GameObject.FindGameObjectsWithTag ("NetworkObject");
		foreach (GameObject go in goArr)
			if (go.name == "NetworkLogic") 
			{
				inGameNetworkBehaviour = go.GetComponent<InGameNetworkBehaviour> ();
				break;
			}
		//inGameNetworkBehaviour.applyName (networkInfo.name);
	}

}

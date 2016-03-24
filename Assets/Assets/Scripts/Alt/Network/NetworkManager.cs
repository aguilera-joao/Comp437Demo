using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string gameName = "Game Name";
	private const string roomName = "Room name";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void startServer(){

		Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
		MasterServer.RegisterHost(gameName, roomName);
	}

	void OnServerInitialized()
	{
		Debug.Log("Server Initializied");
	}
}

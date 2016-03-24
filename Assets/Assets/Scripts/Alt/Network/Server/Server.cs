using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Server : NetworkManager {

	// Use this for initialization

	public GameObject TilePrefab;
	public GameObject UserPrefab;


	public override void OnStartServer(){
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void spawnObject(GameObject prefab){

		GameObject obj = GameObject.Instantiate(prefab);
		NetworkServer.Spawn(obj);
	
	}


}

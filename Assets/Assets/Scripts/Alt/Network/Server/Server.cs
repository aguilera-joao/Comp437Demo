using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Server : NetworkManager {

	// Use this for initialization

	public GameObject TilePrefab;
	public GameObject UserPrefab;


	public List <List<Tile>> map = new List<List<Tile>>();
	public int mapSize = 13;

	public override void OnStartServer(){


	}

	private void spawnObject(GameObject prefab){

		GameObject obj = GameObject.Instantiate(prefab);
		NetworkServer.Spawn(obj);
	
	}

	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
	{

		Debug.Log ("Player has been added!");

		base.OnServerAddPlayer (conn, playerControllerId);
	}

	public override void OnStartHost ()
	{

		generateMap ();



		base.OnStartHost ();
	}

	private void generateMap(){

		for (int i = 0; i < mapSize; i++) {
			List <Tile> row = new List<Tile> ();
			for (int j = 0; j < mapSize; j++) {
				//spawn grid
				GameObject t = Instantiate (TilePrefab, new Vector3 (i - Mathf.Floor (mapSize / 2), 0, -j + Mathf.Floor (mapSize / 2)), Quaternion.Euler (new Vector3 ())) as GameObject;
				Tile tile = t.GetComponent<Tile>();
				tile.gridPosition = new Vector2 (i, j);
				row.Add (tile);
			}
		}

	}


}

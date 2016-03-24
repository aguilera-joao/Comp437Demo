using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : NetworkBehaviour {

	// Use this for initialization

	public GameObject TilePrefab;
	public List <List<Tile>> map = new List<List<Tile>>();
	public int mapSize = 13;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnStartServer(){

		map = new List<List<Tile>> ();

		for (int i = 0; i < mapSize; i++){
			List <Tile> row = new List<Tile> ();
			for (int j = 0; j < mapSize; j++) {
				//spawn grid
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2 (i, j);
				row.Add (tile);

			//	NetworkServer.Spawn (tile);

			}
			map.Add (row);
		}
	}
}

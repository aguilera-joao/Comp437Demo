using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class GameManager : NetworkBehaviour {

	public GameObject TilePrefab;
	public GameObject UserPrefab;
	public GameObject AIPrefab;
	public User user;
	public static GameManager instance;

	public int mapSize = 12;

	List <List<Tile>> map = new List<List<Tile>>();
	//List <Player> users = new List<Player> ();

	public int playerIndex = 0; 
	private float heightLocation = 1.36f;

	[Command]
	public void CmdNextTurn() {

		/*if (playerIndex + 1 < users.Count) {
			playerIndex++;
		} else {

			playerIndex = 0;
		} */
	}


	/*public void movePlayer(Tile destination){

		//users [playerIndex].location = destination.transform.position + heightLocation * Vector3.up;
		//User pl = GetComponent<User>();
		//pl.location = destination.transform.position + heightLocation * Vector3.up;
	}*/

	void Awake() {

		instance = this;
	}

	// Use this for initialization
	void Start () {
	
		generateMap ();
		//generateUsers ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		//users [playerIndex].UpdateTurn ();
	
	}

	void generateMap(){

		map = new List<List<Tile>> ();

		for (int i = 0; i < mapSize; i++){
			List <Tile> row = new List<Tile> ();
			for (int j = 0; j < mapSize; j++) {
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2 (i, j);
				row.Add (tile);
				//NetworkServer.Spawn (tile);
			}
			map.Add (row);
		}
			
	}

	void generateUsers(){

		//User player;


		//player = ((GameObject)Instantiate (UserPrefab, new Vector3 (0 - Mathf.Floor (mapSize / 2), heightLocation, -0 + Mathf.Floor (mapSize / 2)), Quaternion.Euler (new Vector3 ()))).GetComponent<User> ();
		//users.Add (player);
	}

	/*public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId){

		generateUsers ();
		//NetworkServer.AddPlayerForConnection (conn, users [playerIndex], playerControllerId);
	}*/



}

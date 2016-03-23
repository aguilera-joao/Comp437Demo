using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject TilePrefab;
	public GameObject UserPrefab;

	public int mapSize = 12;

	List <List<Tile>> map = new List<List<Tile>>();
	List <Player> users = new List<Player> ();

	private int playerIndex = 0; 


	public void nextTurn() {
	}

	// Use this for initialization
	void Start () {
	
		generateMap ();
		generateUsers ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void generateMap(){

		map = new List<List<Tile>> ();

		for (int i = 0; i < mapSize; i++){
			List <Tile> row = new List<Tile> ();
			for (int j = 0; j < mapSize; j++) {
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2 (i, j);
				row.Add (tile);
			}
			map.Add (row);
		}
			
	}

	void generateUsers(){

		User player, enemy;

		player = ((GameObject)Instantiate(UserPrefab, new Vector3(0 - Mathf.Floor(mapSize/2),1.36f, -0+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<User>();
		enemy  = ((GameObject)Instantiate(UserPrefab, new Vector3((mapSize -1) - Mathf.Floor(mapSize/2),1.36f, -(mapSize - 1)+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<User>(); 
		 
		users.Add(player);
	} 


}

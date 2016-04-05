using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject TilePrefab;
	public GameObject UserPrefab;
	public GameObject AIPrefab;
	public static GameManager instance;

	public int mapSize = 12;

	List <List<Tile>> map = new List<List<Tile>>();
	public List <Player> users = new List<Player> ();

	public int playerIndex = 0; 
	private float heightLocation = 1.36f;

	public void nextTurn() {

		if (playerIndex + 1 < users.Count) {
			playerIndex++;
		} else {

			playerIndex = 0;
		} 
	}

	public void movePlayer(Tile destination){

		users [playerIndex].location = destination.transform.position + heightLocation * Vector3.up;
		//Debug.Log("Player gridLocation is ("+users[playerIndex].currentGridPosition.x + "," + users[playerIndex].currentGridPosition.y + ")");
	}

	void Awake() {

		instance = this;
	}

	// Use this for initialization
	void Start () {
	
		generateMap ();
		generateUsers ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		users [playerIndex].UpdateTurn ();

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
		AIEnemy enemyAI;

		player = ((GameObject)Instantiate(UserPrefab, new Vector3(0 - Mathf.Floor(mapSize/2),heightLocation, -0+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<User>();
		enemy  = ((GameObject)Instantiate(UserPrefab, new Vector3((mapSize -1) - Mathf.Floor(mapSize/2), heightLocation, -(mapSize - 1)+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<User>(); 
		enemyAI = ((GameObject)Instantiate(AIPrefab, new Vector3((mapSize -3) - Mathf.Floor(mapSize/2), .5f, -(mapSize - 3)+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AIEnemy>(); 
		 
		users.Add(player);
		users.Add (enemy);
		users.Add (enemyAI);
	} 

	void OnClick() {

		Debug.Log ("The button has been clicked");
	}




}

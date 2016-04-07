using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//currently, it only sets the player's grid position to the tile the player is on when the player moves to that tile,
//      or when the tile that the player is on is clicked on.

public class GameManager : MonoBehaviour
{
	public GameObject TilePrefab;
	public GameObject UserPrefab;
	public GameObject AIPrefab;
	public static GameManager instance;

    public bool canMove;

	public int mapSize = 12;

	public List <List<Tile>> map = new List<List<Tile>>();
	public List <Player> users = new List<Player> ();
    public List<Tile> tilesToHighlight = new List<Tile>();

	public int playerIndex = 0;

    private float heightLocation = 1.36f;

	public void nextTurn()
    {
        //canMove will set the turn logic so that the players can only move once per turn
        canMove = true;
		if (playerIndex + 1 < users.Count)
        {
			playerIndex++;
		} else {

			playerIndex = 0;
		} 
	}

	public void movePlayer(Tile destination)
    {
		users [playerIndex].location = destination.transform.position + heightLocation * Vector3.up;
        //when player is moved, sets the current player's grid position to the destination tile's grid position
        users[instance.playerIndex].currentGridPosition = destination.gridPosition;
    }

	void Awake()
    {
		instance = this;
        canMove = true;
	}

	void Start ()
    {
		generateMap ();
		generateUsers ();
        /*
        At the moment, we are hard-coding the players' starting positions,
        because the positions are updated when the players are moved, and they obviously aren't moved when instantiated
        This should be fixed in the future
        Possibly call movePlayer right at the start?
        */
        users[0].currentGridPosition = new Vector2(6f, 0f);
        users[1].currentGridPosition = new Vector2(6f, 12f);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
		users [playerIndex].UpdateTurn ();
	}

    //board generation logic
    //this uses a List of Lists, which can be referenced similarly to referencing objects in a 2-D array
    //easy in C# because this generic list is implemented using a base array
	void generateMap()
    {
		map = new List<List<Tile>> ();

		for (int i = 0; i < mapSize; i++)
        {
			List <Tile> row = new List<Tile> ();
			for (int j = 0; j < mapSize; j++)
            {
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2 (i, j);
				row.Add (tile);
			}
			map.Add (row);
		}		
	}

    //generate users list
    //for now, just using a player and second player/enemy
	void generateUsers()
    {
		User player, enemy;
		//AIEnemy enemyAI;

		player = ((GameObject)Instantiate(UserPrefab, new Vector3(0/* - Mathf.Floor(mapSize/2)*/,heightLocation, -0+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<User>();
		enemy  = ((GameObject)Instantiate(UserPrefab, new Vector3(0/*(mapSize -1) - Mathf.Floor(mapSize/2)*/, heightLocation, -(mapSize - 1)+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<User>(); 
		//enemyAI = ((GameObject)Instantiate(AIPrefab, new Vector3((mapSize -3) - Mathf.Floor(mapSize/2), .5f, -(mapSize - 3)+ Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AIEnemy>(); 
		 
		users.Add(player);
		users.Add (enemy);
		//users.Add (enemyAI);
	} 
	void OnClick()
    {
		Debug.Log ("The button has been clicked");
	}
}
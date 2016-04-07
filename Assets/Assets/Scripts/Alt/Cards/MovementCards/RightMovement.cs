using UnityEngine;
using System.Collections;

public class RightMovement : MovementCard
{

	// Use this for initialization
	void Start ()
    {
	
	}

    public void OnMouseDown()
    {
        GameManager gameManagerInstance = GameManager.instance;
        if (gameManagerInstance.canMove)
        {        
            //calls movement function from game manager
            //will move player to the tile at the position of the current user's grid position's x component + 1 and current user's grid component's same y component in the tile map in the game manager instance
            gameManagerInstance.movePlayer(gameManagerInstance.map[(int)gameManagerInstance.users[gameManagerInstance.playerIndex].currentGridPosition.x + 1][(int)gameManagerInstance.users[gameManagerInstance.playerIndex].currentGridPosition.y]);
        }
        gameManagerInstance.canMove = false;
    }

    // Update is called once per frame
    void Update () {
	
	}
}

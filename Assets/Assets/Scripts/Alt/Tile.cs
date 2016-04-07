using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
	public Vector2 gridPosition = Vector2.zero;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    bool compareTile(Tile tile1, Tile tile2)
    {
        bool returns = false;
        if(tile1.gridPosition.x == tile2.gridPosition.x && tile1.gridPosition.y == tile2.gridPosition.y)
        {
            returns = true;
        }
        return returns;
    }

    /*
    This will return true if this tile is a valid tile for the current player to melee
        false if not
    */
    bool CheckForMeleeRange()
    {
        bool returns = false;
        GameManager gameManagerInstance = GameManager.instance;
        int currentPlayer = gameManagerInstance.playerIndex;
        Vector2 currentPlayerGridPosition = gameManagerInstance.users[currentPlayer].currentGridPosition;
        float tileXPosition = this.gridPosition.x;
        float tileYPosition = this.gridPosition.y;
        float playerXPosition = currentPlayerGridPosition.x;
        float playerYPosition = currentPlayerGridPosition.y;

        if((tileXPosition == playerXPosition + 1 && tileYPosition == playerYPosition) ||
            (tileXPosition == playerXPosition - 1 && tileYPosition == playerYPosition) ||
            (tileXPosition == playerXPosition && tileYPosition == playerYPosition + 1) ||
            (tileXPosition == playerXPosition && tileYPosition == playerYPosition - 1))
        {
            returns = true;
        }
        return returns;
    }

    /*
    This will return true if this tile is a valid tile for the current player to shoot at
        false if not
    */
    bool CheckForBulletRange()
    {
        bool returns = false;
        GameManager gameManagerInstance = GameManager.instance;
        int currentPlayer = gameManagerInstance.playerIndex;
        Vector2 currentPlayerGridPosition = gameManagerInstance.users[currentPlayer].currentGridPosition;

        float tileXPosition = this.gridPosition.x;
        float tileYPosition = this.gridPosition.y;
        float playerXPosition = currentPlayerGridPosition.x;
        float playerYPosition = currentPlayerGridPosition.y;

        //List<Tile> tilesToHighlight = gameManagerInstance.tilesToHighlight;
        List<List<Tile>> map = gameManagerInstance.map;

        if (tileXPosition == playerXPosition || tileYPosition == playerYPosition)
        {
            returns = true;
            //fill up tilesToHighlight from gameManagerInstance with tiles between player's y position and the tile's y position
            //  but at the same x position
            if(tileXPosition == playerXPosition)
            {
                float tempTileYPosition = tileYPosition;
                for(int i = 0; i < Mathf.Abs(tileYPosition - playerYPosition); i++)
                {
                    GameManager.instance.tilesToHighlight.Add(map[(int)tileXPosition][(int)tempTileYPosition]);
                    if(tileYPosition < playerYPosition)
                    {
                        tempTileYPosition++;
                    }
                    else if(tileYPosition > playerYPosition)
                    {
                        tempTileYPosition--;
                    }
                }
            }
            else if(tileYPosition == playerYPosition)
            {
                //so, if the tileYPosition == the playerYPosition
                //  fill up tilesToHighlight from gameManagerInstance with tiles between the player's x position and the tile's x position
                //  but at the same y position
                float tempTileXPosition = tileXPosition;
                for (int i = 0; i < Mathf.Abs(tileXPosition - playerXPosition); i++)
                {
                    GameManager.instance.tilesToHighlight.Add(map[(int)tempTileXPosition][(int)tileYPosition]);
                    if (tileXPosition < playerXPosition)
                    {
                        tempTileXPosition++;
                    }
                    else if (tileXPosition > playerXPosition)
                    {
                        tempTileXPosition--;
                    }
                }
            }
        }
        return returns;
    }

    /*
    This will return true if this tile is a valid tile for the current player to boomerang at
        false if not
    */
    bool CheckForBoomerangRange()
    {
        GameManager gameManagerInstance = GameManager.instance;

        return false;
    }

    /*
    This will return true if this tile is a valid tile for the current player to set a mine down on
        false if not
    */
    bool CheckForMineRange()
    {
        GameManager gameManagerInstance = GameManager.instance;

        return false;
    }

    /*
    This will return true if this tile is a valid tile for the current player to set a sentry down on
        false if not
    */
    bool CheckForSentryRange()
    {
        GameManager gameManagerInstance = GameManager.instance;

        return false;
    }

    void OnMouseEnter()
    {
        //GetComponent<Renderer>().material.color = Color.cyan;
        GameManager gameManagerInstance = GameManager.instance;
        List<List<Tile>> map = gameManagerInstance.map;
        List<Tile> tilesToHighlight = gameManagerInstance.tilesToHighlight;
        ActionCard actionCardInstance = ActionCard.actionCardInstance;
        bool actionCardActive = actionCardInstance.actionCardActive;

        /*
        This is going to check if the action card has been activated or not
        If an action card is not active, it will just act normally and highlight tiles cyan
        If an action card is active, it will check which type is active and act correspondingly
        */
        if(!actionCardActive)
        {
            Debug.Log("Action card is not active, so changing tile colors to cyan.");
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if(actionCardInstance.actionCards[0])
        {
            //check if the tile is adjacent to the player
            // if it is, highlight the tile green
            //      if not, highlight the tile red

            Debug.Log("Melee action card is active. Tile effects are active inside Mouse Enter Function.");
            if(CheckForMeleeRange())
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
           
        }
        else if(actionCardInstance.actionCards[1])
        {
            Debug.Log("Bullet action card is active. Tile effects are active inside Mouse Enter Function.");

            if (CheckForBulletRange())
            {
                //GetComponent<Renderer>().material.color = Color.green;
                //fill up tilesToHighlight in Game Manager. This will create a visisble path for bullet
                for(int i = 0; i < tilesToHighlight.Count; i++)
                {
                    tilesToHighlight[i].GetComponent<Renderer>().material.color = Color.green;
                }
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if(actionCardInstance.actionCards[2])
        {
            if (CheckForBoomerangRange())
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if(actionCardInstance.actionCards[3])
        {
            if (CheckForMineRange())
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if(actionCardInstance.actionCards[4])
        {
            if (CheckForSentryRange())
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
        
        Debug.Log ("Position x:" + this.gridPosition.x + "Position y: " + this.gridPosition.y);
	}

	void OnMouseExit()
    {
		GetComponent<Renderer> ().material.color = Color.white;
        for(int i = 0; i < GameManager.instance.tilesToHighlight.Count; i++)
        {
            GameManager.instance.tilesToHighlight[i].GetComponent<Renderer>().material.color = Color.white;
        }
        GameManager.instance.tilesToHighlight = new List<Tile>();
    }

	void OnMouseDown()
    {
        GameManager gameManagerInstance = GameManager.instance;
        //gameManagerInstance.movePlayer(this);
        //when the mouse is down on this tile instance, the current user's grid position will be set to this tile instance's grid position
        //gameManagerInstance.users[gameManagerInstance.playerIndex].currentGridPosition = gridPosition;
	}
}
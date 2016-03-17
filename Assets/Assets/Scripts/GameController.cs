using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public int playerNumber;
	public GameObject gameBoardReference;

	public GameObject player1;
	public GameObject player2;

	private GameObject [,] boardArray;
	private CapsuleCollider player1Collider;
	private CapsuleCollider player2Collider;


	// Use this for initialization
	void Start () 
	{
		playerNumber = 1;
	}
	void Awake()
	{
		boardArray = gameBoardReference.GetComponent<GameBoard> ().getBoardArray ();
		player1Collider = player1.GetComponent<CapsuleCollider> ();
		player2Collider = player2.GetComponent<CapsuleCollider> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	private class CubeNCubePosition : GameController
	{
		public int currentRow;
		public int currentCol;
		public void setRow(int r)
		{
			currentRow = r;
		}
		public void setCol(int c)
		{
			currentCol = c;
		}
	}
	void searchBoard()
	{
		for(int r = 0; r < boardArray.GetLength(0); r++)
		{
			for(int c = 0; c < boardArray.GetLength(1); c++)
			{
				boardArray [r, c].GetComponent<BoxCollider> ().enabled = true;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour
{
    public GameObject boardSpace;
    public GameObject gameBoard;
    public GameObject gridTile;

    private GameObject [,] boardArray;

    private Transform boardTransform;
    private float boardSizeX;
    private float boardSizeZ;

    private Transform spaceTransform;
    private float spaceSizeX;
    private float spaceSizeZ;

    private float currentCubePositionX;
    private float currentCubePositionZ;
    private float cubePositionY;

    private Vector3 newVector;
	// Use this for initialization

	public GameObject[,] getBoardArray()
	{
		return this.boardArray;
	}
    void Awake()
    {
        //get the BOARD OBJECT transform component, store in boardTransform
        boardTransform = GetComponent<Transform>();

        //set board size variables for later access
        boardSizeX = boardTransform.lossyScale.x;
        boardSizeZ = boardTransform.lossyScale.z;

        //get current cube space transform component
        spaceTransform = boardSpace.GetComponent<Transform>();

        //get current cube space size
        spaceSizeX = spaceTransform.lossyScale.x;
        spaceSizeZ = spaceTransform.lossyScale.z;

        //get current cube space position in world
        //this will be used to reference the last cube spawned position to spawn next cube
        currentCubePositionX = spaceTransform.position.x;
        currentCubePositionZ = spaceTransform.position.z;
        cubePositionY = spaceTransform.position.y;
        //call spawnBoardSpaces
        spawnSpaces();
        StartCoroutine(testGridFunction());
        //StartCoroutine(drawGrid());
        //drawGrid();
        //drawColliders();
    }
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void spawnSpaces()
    {
        boardArray = new GameObject[(int)boardSizeZ, (int)boardSizeX];
        for(int r = 0; r < boardSizeZ; r++)
        {
            int c = 0;
            for(c = 0; c < boardSizeX; c++)
            {
                
                newVector = new Vector3(currentCubePositionX, cubePositionY, currentCubePositionZ);
                currentCubePositionX = currentCubePositionX + 1;
                GameObject newCube = Instantiate(boardSpace, newVector, Quaternion.identity) as GameObject;
                boardArray[r, c] = newCube;
                //newCube.GetComponent<MeshRenderer>().enabled = false;
                
                //OnDrawGizmos
            }
            currentCubePositionZ--;
            currentCubePositionX-=c;   
        }
    }
    IEnumerator testGridFunction()
    {
        for(int r = 0; r < boardArray.GetLength(0); r++)
        {
            for(int c = 0; c < boardArray.GetLength(1); c++)
            {
                boardArray[r, c].GetComponent<MeshRenderer>().enabled = false;
				boardArray [r, c].GetComponent<BoxCollider> ().enabled = false;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
    IEnumerator drawGrid()
    {
        for (int r = 0; r < boardArray.GetLength(0); r++)
        {
            for (int c = 0; c < boardArray.GetLength(1); c++)
            {
                Instantiate(gridTile, new Vector3((boardArray[r, c].GetComponent<Transform>().position.x - 0.5f), 0, boardArray[r, c].GetComponent<Transform>().position.z), Quaternion.identity);
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
    void drawColliders()
    {

    }
}
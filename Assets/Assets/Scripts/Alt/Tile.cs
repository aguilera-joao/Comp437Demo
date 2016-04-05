using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){

		GetComponent<Renderer> ().material.color = Color.cyan;

		Debug.Log ("Position x:" + this.gridPosition.x + "Position y: " + this.gridPosition.y);
	}

	void OnMouseExit(){

		GetComponent<Renderer> ().material.color = Color.white;
	}

	void OnMouseDown(){

		GameManager.instance.movePlayer (this);
		GameManager.instance.users [GameManager.instance.playerIndex].currentGridPosition = gridPosition;
	}

}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class Player : NetworkBehaviour {

	// Use this for initialization

	public Vector3 location;
	public bool moving = false;

	//attributes
	public int health;

	void Awake(){

		location = this.transform.position;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!isLocalPlayer) {

			return;
		}
	}


	public virtual void UpdateTurn(){
	}
}

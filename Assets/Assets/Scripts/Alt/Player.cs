using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

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
	
	}

	public virtual void UpdateTurn(){
	}
}

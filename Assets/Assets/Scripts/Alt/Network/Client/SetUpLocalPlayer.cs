using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SetUpLocalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
		if (isLocalPlayer) {

			GetComponent<User> ().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

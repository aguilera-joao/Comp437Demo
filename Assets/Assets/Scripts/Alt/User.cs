using UnityEngine;
using System.Collections;

public class User : Player {

	public float speed = 8.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void UpdateTurn () {

		Debug.Log ("I am being called");

		if (Vector3.Distance (location, transform.position) > 0.1f) {

			transform.position += (location - transform.position).normalized * speed * Time.deltaTime;

			if (Vector3.Distance (location, transform.position) <= 0.1f) {

				transform.position = location;
				GameManager.instance.nextTurn ();
			}
		}

		base.UpdateTurn ();
	}
}

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

		if (Vector3.Distance (location, transform.position) > 0.2f) {

			transform.position += (location - transform.position).normalized * speed * Time.deltaTime;

			if (Vector3.Distance (location, transform.position) <= 0.2f) {

				transform.position = location;
				//GameManager.instance.nextTurn ();
			}
		}

		base.UpdateTurn ();
	}
}

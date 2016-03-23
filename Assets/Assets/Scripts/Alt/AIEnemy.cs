using UnityEngine;
using System.Collections;

public class AIEnemy : Player {

	// Use this for initialization

	public float speed = 8.0f; 
	public float height = 1.36f;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void UpdateTurn () {



		if (Vector3.Distance (location, transform.position) > 0.1f) {

			transform.position += (location - transform.position).normalized * speed * Time.deltaTime;

			if (Vector3.Distance (location, transform.position) <= 0.1f) {

				transform.position = location;
				GameManager.instance.nextTurn ();
			}
		} else {

			//location = new Vector3 (0 - Mathf.Floor (GameManager.instance.mapSize / 2), height, -0 + Mathf.Floor(GameManager.instance.mapSize / 2));
		}

		base.UpdateTurn ();
	}
}

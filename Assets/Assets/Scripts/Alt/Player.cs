using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public Vector3 location;
    public Vector2 currentGridPosition;
	public bool moving = false;

	//attributes
	public int health;
    void OnTriggerEnter(Collider other)
    {

    }
	void Awake()
    {
		location = this.transform.position; 
	}

	void Start ()
    {
	
	}
	
    void checkForHit()
    {

    }

	// Update is called once per frame
	void Update ()
    {
        checkForHit();
	}

	public virtual void UpdateTurn()
    {
	}
}

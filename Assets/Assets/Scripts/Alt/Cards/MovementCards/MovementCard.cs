using UnityEngine;
using System.Collections;

public class MovementCard : Card
{
    public static MovementCard movementInstance;
    void Awake()
    {
        movementInstance = this;
    }
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

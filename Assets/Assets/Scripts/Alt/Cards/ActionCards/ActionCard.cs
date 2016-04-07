using UnityEngine;
using System.Collections;

public class ActionCard : Card
{
    /*
    public Color lerpedColor;
    public Color startingColor;
    */
    public bool actionCardActive;
    public static ActionCard actionCardInstance;

    public bool[] actionCards;

    void Awake()
    {
        actionCardInstance = this;
        /*
        GetComponent<Renderer>().material.color = Color.red;
        lerpedColor = GetComponent<Renderer>().material.color;
        startingColor = GetComponent<Renderer>().material.color;
        */
        actionCardActive = false;

        actionCards = new bool[5];
        for(int i = 0; i < actionCards.GetLength(0); i++)
        {
            actionCards[i] = false;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
}
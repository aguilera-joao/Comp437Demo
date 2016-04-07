using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{
    /*
    Our melee card will let the player melee towards any adjacent square of their choosing
    */
    public ActionCard actionCardInstance;

    public Color lerpedColor;
    public Color startingColor;

    void Awake()
    {
        actionCardInstance = ActionCard.actionCardInstance;
        GetComponent<Renderer>().material.color = Color.red;
        lerpedColor = GetComponent<Renderer>().material.color;
        startingColor = GetComponent<Renderer>().material.color;
    }
    public void OnMouseDown()
    {
        /*
        This will set the action card as active or inactive
        */
        if (actionCardInstance.actionCardActive)
        {
            actionCardInstance.actionCardActive = false;
            Debug.Log("Action Card Active is set to: " + actionCardInstance.actionCardActive);
            //Debug.Log("Position x:" + this.gridPosition.x + "Position y: " + this.gridPosition.y);
        }
        else
        {
            actionCardInstance.actionCardActive = true;
            Debug.Log("Action Card Active is set to: " + actionCardInstance.actionCardActive);
        }

        /*
        This will set the specific melee card as active or inactive
        */
        if (actionCardInstance.actionCards[0])
        {
            actionCardInstance.actionCards[0] = false;
        }
        else
        {
            actionCardInstance.actionCards[0] = true;
        }
    }
    
    public void Update()
    {
        if (actionCardInstance.actionCards[0])
        {
            lerpedColor = Color.Lerp(startingColor, Color.white, Mathf.PingPong(Time.time, 1));
            GetComponent<Renderer>().material.color = lerpedColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = startingColor;
        }
    }
}
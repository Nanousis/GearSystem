using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mybutton : MonoBehaviour
{
    public bool isPressed;          //our bool that returns true if the button is being pressed

    public float dampenPress = 0;   //this returns 1 if the button is pressed after a short delay.
    public float sensitivity = 2f;  //How fast the above float turns to 1
    // Start is called before the first frame update
    void Start()
    {
        SetUpButton();              //we set up our button eventTriggers
    }

    // Update is called once per frame
    void Update()
    {
                                    // here we change the value of the dampenPress based on time passed
        if (isPressed)
        {
            dampenPress += sensitivity * Time.deltaTime;
        }
        else
        {
            dampenPress -= sensitivity * Time.deltaTime;
        }
        dampenPress = Mathf.Clamp01(dampenPress);
    }
    void SetUpButton()
    {
        //we create a new event trigger
        EventTrigger trigger = gameObject.AddComponent<EventTrigger>();
        
        //we set up a new entry for our event trigger for PointerDown
        var pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((e) => onClickDown());
        
        //we create an entry for PointerUp as well
        var pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((e) => onClickUp());

        //we push the changes to the EventTrigger
        trigger.triggers.Add(pointerDown);
        trigger.triggers.Add(pointerUp);


    }

    public void onClickDown()
    {
        isPressed = true;
    }

    public void onClickUp()
    {
        isPressed = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TextUpdateManager : MonoBehaviour //An instance of this class is instantiated when the GameObject is it attached to is instantiated.
{
    public TextUpdateEvent textUpdateEvent; //Declaring a reference to a TextUpdateEvent.

    public void Start() //Called via Unity Magic when an instance of the TextUpdateManager class is instantiated.
    {
        textUpdateEvent = new TextUpdateEvent(); //Instantiating a new instance of TextUpdateEvent and assigning the reference to it.
    }
    public void TriggerTextUpdate(string newText) //This method can be called by any class holding a reference to the TextUpdateManager to Invoke the TextUpdateEvent.
    {
        textUpdateEvent.Invoke(newText); //Invoke the TextUpdateEvent.
    }
}

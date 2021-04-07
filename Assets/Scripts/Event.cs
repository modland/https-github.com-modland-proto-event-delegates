using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// events are a special type of delegate that allows us to create a broadcast system
// this allows other classes and objects to subscribe or desubscribe to our delegates.
public class Event : MonoBehaviour
{

    public delegate void ActionClick();
    // what we want to do is create an event that will allow the cubes to subscribe to ActionClick;

    public static event ActionClick onClick;
    // and declare it like a normal variable
    // now "Listeners" can subscribe to this event.
    // the reason we use an event instead of a delegate is that events have inherent security while delegates do not
    // if we uste the delegate variable then other classes could incoke and control the use of our delegate
    // wheras if you use an event it just allows subscription and desubscription to the event


    public void ButtonClick()
    {
        // turn all cubes red
        onClick?.Invoke(); // treat this delegate like a method
    }

    // alt example of an event delegate that takes a vector3 signature
    public delegate void ActionSpaceBar(Vector3 vector3);
    public static event ActionSpaceBar onSpace;
    public Vector3 waypoint = new Vector3(2f,3f,0f);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSpace?.Invoke(waypoint);
        }
    }
}

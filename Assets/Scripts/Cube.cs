using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void Start()
    {
        // we want the cube to subscribe to our event delegate
        Event.onClick += TurnRed; // this registers TurnRed to onClick;
        Event.onSpace += Teleport;
    }

    public void TurnRed()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void Teleport(Vector3 moveHere)
    {
        this.gameObject.transform.position = moveHere;
    }

    // and when you are subscribing to an event you allways want to unsubscribe somewhere. Usually when you destroy the object.
    private void OnDisable()
    {
        Event.onClick -= TurnRed;
        Event.onSpace -= Teleport;
    }
}

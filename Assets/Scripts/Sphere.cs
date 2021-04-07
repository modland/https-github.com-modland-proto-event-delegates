using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public void Start()
    {
        Event.onClick += Fall;
    }
    public void Fall()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
    private void OnDisable()
    {
        Event.onClick -= Fall;
    }
}

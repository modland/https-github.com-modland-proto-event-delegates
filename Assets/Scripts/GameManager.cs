using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public delegate void Spawner(Transform spawn);
    public static event Spawner spawner;
    public Transform t;

    public delegate void Destroyer();
    public static event Destroyer destroyer;

    public static Action<int> healPlayer;
    public static Action<int> damagePlayer;

    private void Start()
    {
        Player.died += ResetPlayer;
        Player.sublimate += ResetPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Destroyer Invoked");
            destroyer?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Healer Invoked");
            healPlayer?.Invoke(12);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Damage Invoked");
            damagePlayer?.Invoke(-11);
        }
    }

    public void ResetPlayer()
    {
        Debug.Log("Respawn Invoked");
        spawner?.Invoke(t);
    }
}

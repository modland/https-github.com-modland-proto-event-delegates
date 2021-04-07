using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health { get; set; }
    public int maxHealth = 100;
    [SerializeField] private Vector3 playerOffset = new Vector3(0f, .0f, 0f);

    // examples of equivalent (delegate with event) and action
    public delegate void OnBirth(int health);
    public static event OnBirth reBorn;
    
    public delegate void OnDeath();
    public static event OnDeath died;

    // Action is equivalent to a delegate event combo. It requires using System;
    public static Action<int> healthReceived;
    public static Action<int> damageReceived;
    public static Action sublimate;

    void Start()
    {
        Health = 100;
        GameManager.destroyer += Death;
        GameManager.spawner += NewLife;
        GameManager.damagePlayer += Damage;
        GameManager.healPlayer += Heal;
    }


    public void Heal(int amt)
    {
        Debug.Log("Heal");
        Health += amt;
        if (Health>200)
        {
            Sublimate();
        }
        healthReceived?.Invoke(amt);
    }


    public void Sublimate()
    {
        Debug.Log("Sublimate");
        sublimate?.Invoke();
    }


    public void Damage(int amt)
    {
        Debug.Log("Damage");
        Health += amt;
        if (Health<0)
        {
            Death();
        }
        damageReceived?.Invoke(amt);
    }


    public void Death()
    {
        died?.Invoke();
    }


    public void NewLife(Transform spawn)
    {
        Health = maxHealth;
        transform.position = spawn.position + playerOffset;
        transform.rotation = spawn.rotation;
        reBorn?.Invoke(maxHealth);
    }
}

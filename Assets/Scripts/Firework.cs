using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Firework : MonoBehaviour
{
    VisualEffect visualEffect;
    VFXEventAttribute eventAttribute;
    public AudioClip pop;

    private void Start()
    {
        visualEffect = GetComponent<VisualEffect>();
        Event.onClick += visualEffect.Play; // for scene 1
        Player.sublimate += visualEffect.Play; // for scene 3
        //Event.onClick += pop.
    }

    private void OnDisable()
    {
        Event.onClick -= visualEffect.Play;
        Player.sublimate -= visualEffect.Play;
    }
}

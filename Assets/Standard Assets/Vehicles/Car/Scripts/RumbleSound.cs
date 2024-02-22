using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleSound : MonoBehaviour
{
    private AudioSource player;
    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (SaveScript.Rumble1 == true || SaveScript.Rumble2 == true)
        {
            player.Play();
        }
        else
        {
            player.Stop();
        }
    }
}

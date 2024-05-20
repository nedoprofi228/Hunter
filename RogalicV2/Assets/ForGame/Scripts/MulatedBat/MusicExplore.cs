using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicExplore : MonoBehaviour
{
    AudioSource src;

    public void PlayExploreMusic()
    {
        src = GetComponent<AudioSource>();
        src.Play();
    }
}

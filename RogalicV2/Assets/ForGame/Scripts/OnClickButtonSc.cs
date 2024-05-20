using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickButtonSc : MonoBehaviour
{
    private AudioSource _src;

    public void Start()
    {
        _src = GetComponent<AudioSource>();
    }
    public void PlayMusic()
    {
        _src.Play();
    }
}

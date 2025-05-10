using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    public AudioClip MainBgm;
    private AudioSource audio;
    private void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = MainBgm;
        audio.Play();
        DontDestroyOnLoad(gameObject);
    } 
    
}

using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    private List<AudioSource> Audios = new List<AudioSource>();
    private List<AudioSource> UsedAudio = new List<AudioSource>();
    public AudioManage instant;

    public AudioManage Instant
    {
        get
        {
            if (instant == null)
            {
                var g = new GameObject("AudioManage");
                instant =  g.AddComponent<AudioManage>();
            }
            return instant;
        }
    }
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip tclip)
    {
        AudioSource a;
        if (Audios.Count > 0)
        {
            a = Audios[0];
            UsedAudio.Add(a);
            Audios.Remove(a);
        }
        else
        {
            a  = gameObject.AddComponent<AudioSource>();
            UsedAudio.Add(a);
        }
        asyncplay(a,tclip);
    }

    async void asyncplay(AudioSource a,AudioClip c)
    {
        a.clip = c;
        a.Play();
        await UniTask.WaitUntil(() => a.isPlaying);
        UsedAudio.Remove(a);
        Audios.Add(a);
    }
    
    
}

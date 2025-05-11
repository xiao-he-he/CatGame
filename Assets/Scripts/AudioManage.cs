using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    private Dictionary<AudioSource, AudioClip> UsedClip;
    private List<AudioSource> Audios = new List<AudioSource>();
    private List<AudioSource> UsedAudio = new List<AudioSource>();
    private static AudioManage instant;

    public static AudioManage Instant
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

    public void PlayClip(AudioClip tclip,bool isloop = false)
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
        a.loop = isloop;
        asyncplay(a,tclip);
    }

    //暂停特定音效
    public void StopClip(AudioClip clip)
    {
        foreach (var VARIABLE in UsedClip)
        {
            if (VARIABLE.Value == clip)
            {
                VARIABLE.Key.Stop();
            }
        }
    }
    

    async void asyncplay(AudioSource a,AudioClip c)
    {
        a.clip = c;
        a.Play();
        UsedClip[a] = c;
        await UniTask.WaitUntil(() => !a.isPlaying);
        UsedAudio.Remove(a);
        Audios.Add(a);
        UsedClip.Remove(a);
        a.loop = false;
    }
    
    
}

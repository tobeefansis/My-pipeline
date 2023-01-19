using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicControl : Singleton<MusicControl>
{
    private AudioSource audioSource;
    private int index;
    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
        
    }

    private void LateUpdate()
    {
        if (audioSource.isPlaying) return;
        index++;
        if (index>=audioClips.Count)
        {
            index -= audioClips.Count;
        }

        audioSource.clip = audioClips[index];
        audioSource.Play();
    }
}
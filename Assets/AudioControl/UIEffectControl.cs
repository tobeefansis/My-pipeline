using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UIEffectControl : Singleton<UIEffectControl>
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip buttonClickClip;

    protected override void Awake()
    {
        base.Awake();
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void ClickPlay()
    {
        Debug.Log("Click");
        audioSource.clip = buttonClickClip;
        audioSource.Play();
    }
}
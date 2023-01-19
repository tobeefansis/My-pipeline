using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControlSetter : MonoBehaviour
{
    [SerializeField] private AudioController.Group group;
    [SerializeField] private Slider slider;
    [SerializeField] private Toggle toggle;
    public void ChangeValue(float value)
    {
        if (AudioController.InstanceExists)
        {
            AudioController.I.ChangeValue(group,value);
        }
        else
        {
            Debug.LogError("AudioController Not Exists");
        }
    } 
    public void ChangeMute(bool value)
    {
        if (AudioController.InstanceExists)
        {
            AudioController.I.SetMute(group,value);
        }
        else
        {
            Debug.LogError("AudioController Not Exists");
        }
    }

    

    private void Start()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        if (AudioController.InstanceExists)
        {
            
            if (slider)
            {
                slider.value = AudioController.I.GetValue(group);
            }
            if (toggle)
            {
                toggle.isOn = AudioController.I.GetMute(group);
            }
        }
        else
        {
            Debug.LogError("AudioController Not Exists");
        }
    }
}

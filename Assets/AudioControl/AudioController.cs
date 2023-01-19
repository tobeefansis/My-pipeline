using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : Singleton<AudioController>
{
    public enum Group
    {
        Sound,
        Effects,
        Music,
    }

    private const string key = "AudioController";
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private List<AudioGroupSettings> audioGroupSettings = new List<AudioGroupSettings>();

    public bool GetMute(Group group)
    {
        var settings = GetSettings(group);
        return settings.IsMute;
    }

    public float GetValue(Group group)
    {
        var settings = GetSettings(group);
        return settings.Value;
    }
    public void SetMute(Group group, bool value)
    {
        var settings = GetSettings(group);
        settings.SetMute(value);
        UpdateValue(settings);
        Save();
    }

    public void ChangeValue(Group group, float newValue)
    {
        var settings = GetSettings(group);
        settings.ChangeValue(Mathf.Clamp(newValue, AudioGroupSettings.MinValue, AudioGroupSettings.MaxValue));
        UpdateValue(settings);
        Save();
    }

    protected override void Awake()
    {
        base.Awake();
        Load();
        foreach (var settings in audioGroupSettings)
        {
            UpdateValue(settings);
        }
    }


    private void Save()
    {
        var settingsData = audioGroupSettings.Select(JsonUtility.ToJson).ToList();
        SaveSystem.Save(key, settingsData);
    }

    private void Load()
    {
        var values = LoadSystem.LoadValues(key);
        if (values.Count==0)return;
        
        audioGroupSettings.Clear();
        audioGroupSettings= values.Select(JsonUtility.FromJson<AudioGroupSettings>).ToList();
    }

    private void UpdateValue(AudioGroupSettings settings)
    {
        var value = settings.IsMute ? AudioGroupSettings.MinValue : settings.Value;

        mixer.SetFloat(settings.Group.ToString(), value);
    }

    private AudioGroupSettings GetSettings(Group group)
    {
        foreach (var settings in audioGroupSettings.Where(settings => settings.Group == group))
        {
            return settings;
        }

        Debug.LogError("NullReferenceException");
        return null;
    }


    [System.Serializable]
    public class AudioGroupSettings
    {
        public const float MaxValue = 0;
        public const float MinValue = -60;
        [SerializeField] private Group group;
        [SerializeField] private float value;
        [SerializeField] private bool isMute;

        public AudioGroupSettings(Group group, float value, bool isMute)
        {
            this.group = group;
            this.value = value;
            this.isMute = isMute;
        }

        public Group Group => group;
        public float Value => value;
        public bool IsMute => isMute;

        public bool SetMute(bool newValue)
        {
            isMute = newValue;
            return isMute;
        }

        public void ChangeValue(float newValue)
        {
            value = Mathf.Clamp(newValue, MinValue, MaxValue);
        }
    }
}
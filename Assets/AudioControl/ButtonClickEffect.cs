using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickEffect : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    private static void Click()
    {
        if (UIEffectControl.InstanceExists)
        {
            UIEffectControl.I.ClickPlay();
        }
    }
}
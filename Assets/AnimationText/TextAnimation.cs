using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextAnimation : MonoBehaviour
{
    [SerializeField] [TextArea(3, 10)] private string text;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] [Range(0, 1)] private float timeStep;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        textMeshPro.text = "";
        foreach (var ch in text)
        {
            textMeshPro.text += ch;
            if (ch==' ')continue;
            yield return new WaitForSeconds(timeStep);
        }
    }
}

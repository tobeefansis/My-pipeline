using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UIScreenSystem;
using UnityEngine;
using UnityEngine.Events;

public class UILevelHolder : UIHolder<Level>
{
    [SerializeField] private TextMeshProUGUI openLevelNameText;
    [SerializeField] private TextMeshProUGUI closeLevelNameText;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private RectTransform progressTransform;
    [SerializeField] private UnityEvent<bool> open;
    [SerializeField] private UnityEvent<bool> close;

    public override void Refresh(Level level)
    {
        base.Refresh(level);
        open.Invoke(level.IsOpen);
        close.Invoke(!level.IsOpen);
        openLevelNameText.text = level.LevelName;
        closeLevelNameText.text = level.LevelName;
        progressText.text = $"{level.Progress}%";
        progressTransform.localScale = Vector3.one * level.Progress * .01f;
    }

    public void Select()
    {
        Debug.Log($"Select level {Item.LevelName}");
        LevelLoader.I.LoadLevel(Item);
        ScreenManager.I.OpenScreen(ScreenManager.I.Screens[0]);
    }
}
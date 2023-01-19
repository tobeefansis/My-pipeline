using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class UIItemParameterHolder : UIHolder<ItemParameter>
{
    [SerializeField] private Image parameterImageHolder;
    [SerializeField] private TextMeshProUGUI parameterNameHolder;
    public override void Refresh(ItemParameter item)
    {
        base.Refresh(item);
        parameterImageHolder.sprite = item.ParameterImage;
        parameterNameHolder.text = item.ParameterName;
    }
}

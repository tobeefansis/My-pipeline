using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class UILevelList : UIElementsList<Level>
{
    void Start()
    {
        base.Refresh();
    }

    [ContextMenu("Refresh")]
    void Refresh() => base.Refresh();

    public override void Initialize()
    {
    }

    public override void SortBy()
    {
    }
}
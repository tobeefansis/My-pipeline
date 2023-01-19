using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class UIInventory : UIElementsList<Item>
{
    
    void Start()
    {
        Refresh();
    }

    [ContextMenu("Refresh")]

    

    public override void Initialize()
    {
        
    }

    public override void SortBy()
    {
      
    }
}

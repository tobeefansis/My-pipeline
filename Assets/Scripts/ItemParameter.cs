using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParameter : MonoBehaviour
{
   [SerializeField] private string parameterName;
   [SerializeField] private Sprite parameterImage;

   public string ParameterName
   {
      get => parameterName;
      set => parameterName = value;
   }

   public Sprite ParameterImage
   {
      get => parameterImage;
      set => parameterImage = value;
   }
}

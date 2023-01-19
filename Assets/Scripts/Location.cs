 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
 [SerializeField] private List<Item> items = new List<Item>();

 public List<Item> Items
 {
  get => items;
  set => items = value;
 }
}

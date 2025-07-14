using System.Collections.Generic;
using UnityEngine;

public abstract class ItemsCollection : ScriptableObject 
{
    [SerializeField] public string itemName = "Items Collection";
    [SerializeField] public List<Item> itemsCollection = new List<Item>();

    [TextArea(3, 10)]
    [SerializeField] private string description = "Item function and characteristics are: ";
}
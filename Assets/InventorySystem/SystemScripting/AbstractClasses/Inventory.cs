using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class for creating different types of inventories.
/// Contains a list of items collected 
/// and a dictionary to count stacks of items.
/// 
/// Use a derived class to implement specific inventory behavior.
/// For Example GeneralInventory class for inventories that behave as items storage
/// </summary>

public abstract class Inventory : ScriptableObject 
{
    [SerializeField] public string inventoryName = "General Inventory";
    [SerializeField] public List<Item> itemsCollected = new List<Item>();

    public Dictionary<string, int> countStack = new Dictionary<string, int>();


    [TextArea(3, 10)]
    [SerializeField] private string description = "Inventory to store or record: ";
    
}
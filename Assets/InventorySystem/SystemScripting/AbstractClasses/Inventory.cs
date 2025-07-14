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
    [SerializeField] public InventoryCategory category;
    [SerializeField] public List<Item> itemsCollected = new List<Item>();

    public Dictionary<string, int> countStack = new Dictionary<string, int>();


    [TextArea(3, 10)]
    [SerializeField] private string description = "Inventory to store or record: ";

    /// <summary>
    /// This is a virtual, when called will actually call the childs method.
    /// This is used to be able to call the specific inventory type method bu calling the parent,
    /// (eg. GeneralInventory.AddToInventory())
    /// that way scripts only need to reference the Inventory class but will execute the method of the corresponding child class from where they are calling
    /// </summary>
    public virtual void AddToInventory(Item item) { }
}
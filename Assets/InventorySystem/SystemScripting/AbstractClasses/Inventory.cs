using ScriptableObjects.Events;
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
    [SerializeField] public VoidEvent OnInventoryChanged; // "Raised whenever Add/Remove/Clear runs"    
    [SerializeField] public List<Item> itemsCollected = new List<Item>();

    //Keeps track of amount of items stacked in a slot
    public Dictionary<string, int> countStack = new Dictionary<string, int>();

    //Keeps track of order of stacks to display
    public List<string> stackOrder = new List<string>();


    [TextArea(3, 10)]
    [SerializeField] private string description = "Inventory to store or record: ";


    /// <summary>
    /// This is a virtual, when called will actually call the childs method.
    /// This is used to be able to call the specific inventory type method by calling the parent,
    /// (eg. GeneralInventory.AddToInventory())
    /// that way scripts only need to reference the Inventory class but will execute the method of the corresponding child class from where they are calling
    /// </summary>
    public virtual bool TryAddToInventory(Item item) { return false; }

    public virtual void AddToInventory(Item item) 
    {
        itemsCollected.Add(item);
        

        AddItemToStack(item.itemName); //Add item to countStack dictionary to keep track of how many items of the same type are in the inventory
        

        //Debug.Log(countStack[item.itemName]);

        OnInventoryChanged?.Raise(); //Review this code is still needed!
        //Debug.Log($"{item.name} added to {category} inventory.");
    }
    public virtual void RemoveFromInventory(int itemIndex) 
    {
        if (itemIndex >= 0 && itemIndex < itemsCollected.Count  )
        {
            
            
            RemoveItemFromStack(itemsCollected[itemIndex].itemName);
            itemsCollected.RemoveAt(itemIndex);
            OnInventoryChanged?.Raise();
        }
    }

    public virtual void ClearInventory()
    {
        itemsCollected.Clear();
        countStack.Clear();
        stackOrder.Clear();
        OnInventoryChanged?.Raise();
    }
    /// <summary>
    /// Compares itemsCollected Unique items with stack, if any difference 
    /// it rebuilds full countStack and stackOrder to avoid errors loading 
    /// inventory, maybe caused by modifying itemsCollected directly 
    /// (for example: in the editor)
    /// </summary>
    public void UpdateDictionary()
    {
        List<Item> countUniqueItems = new List<Item>();
        foreach (var item in itemsCollected)
        {
            if (!countUniqueItems.Contains(item))
                countUniqueItems.Add(item);
        }
        if (countStack.Count != countUniqueItems.Count )
        {
            // Clear the countStack and stackOrder dictionary before updating it
            countStack.Clear();
            stackOrder.Clear();
            // Populate the countStack and stackOrder dictionary with the items collected
            foreach (Item item in itemsCollected)
            {
                AddItemToStack(item.itemName);
            }
        }         
    }

    /// <summary>
    /// Adds an item to the countStack dictionary or increments the count 
    /// if it already exists. Also updates the stackOrder list 
    /// to maintain order of UI display.
    /// </summary>

    public void AddItemToStack(string itemName)
    {
        if(countStack.ContainsKey(itemName))
        {
            countStack[itemName]++;
        }
        else
        {
            countStack[itemName] = 1;
            stackOrder.Add(itemName);
        }
    }

    /// <summary>
    /// Removes an item from the countStack dictionary, decrementing the count or 
    /// removing the entry if it reaches zero. Also updates the stackOrder list 
    /// to maintain order of UI display.
    /// </summary>
    public void RemoveItemFromStack(string itemName)
    {
        if (countStack.ContainsKey(itemName))
        {
            countStack[itemName]--;
            if (countStack[itemName] <= 0)
            {
                countStack.Remove(itemName);
                stackOrder.Remove(itemName);
            }
        }
    }    
}
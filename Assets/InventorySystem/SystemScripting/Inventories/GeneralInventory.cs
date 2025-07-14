using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create instances of this class for inventories that behave as items storage.
/// It counts slots used and stack items in a slot if they are stackable.
/// If a different behavior is needed, create a new class that inherits from Inventory.
/// </summary>

[CreateAssetMenu(fileName = "GeneralInventory", menuName = "Inventories/GeneralInventory")]
public class GeneralInventory : Inventory
{
    [SerializeField] private bool uniqueItems = false;
    [SerializeField] private bool unlimitedTotalItems = false;
    [SerializeField] private bool itemsStack = true;
    [SerializeField] private bool unlimitedStack = false;
    [SerializeField] private int maxTotalSlots = 20;
    [SerializeField] private int itemStackLimit = 20;
    [SerializeField] private int maxTotalItems = 100;

    // When enabled organize inventory items into stacks to know how mamny slots there are occupied
    private void OnEnable()
    {
        //Avoids SO information to be lost when changing between scenes. If the next scene doesn't use the SO unity destroys the changes to it in the build
        hideFlags = HideFlags.DontUnloadUnusedAsset;

        UpdateDictionary();
    }

    public override void AddToInventory(Item item)
    {
        UpdateDictionary();

        bool hasItem = countStack.ContainsKey(item.itemName);
        int currentCount = hasItem ? countStack[item.itemName] : 0;
                
        Debug.Log($"Current count of {item.itemName}: {currentCount}");

        // Adds all items if total items are unlimited, as long as it's not unique items and item is already collected
        if (unlimitedTotalItems)
        {
            // Check if item is unique and already exists in the inventory or if the inventory has no limit
            if ((uniqueItems && !hasItem))
            {
                // Add item and stack
                itemsCollected.Add(item);
                countStack[item.itemName] = currentCount + 1;
                Debug.Log($"{item.name} added to {category} inventory.");
            }
            else if (!uniqueItems)
            {
                // Add item and stack
                itemsCollected.Add(item);
                countStack[item.itemName] = currentCount + 1;
                Debug.Log($"{item.name} added to {category} inventory.");
            }
        }        
        else if (itemsCollected.Count < maxTotalItems) // Check if inventory is not full
        {
            if (itemsStack)
            {
                if (uniqueItems && !hasItem)
                {
                    if (unlimitedStack && countStack.Count < maxTotalSlots)
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                    else if (unlimitedStack && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                    else if (currentCount < itemStackLimit && countStack.Count < maxTotalSlots)
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                    else if (currentCount < itemStackLimit && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                }
                else if (!uniqueItems)
                {
                    if (unlimitedStack && countStack.Count < maxTotalSlots)
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                    else if (unlimitedStack && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                    else if (currentCount < itemStackLimit && countStack.Count < maxTotalSlots)
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                    else if (currentCount < itemStackLimit && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
                    {
                        // Add item and stack
                        itemsCollected.Add(item);
                        countStack[item.itemName] = currentCount + 1;
                        Debug.Log($"{item.name} added to {category} inventory.");
                    }
                }
            }
            else if (itemsCollected.Count < maxTotalSlots)
            {
                if (uniqueItems && !hasItem)
                {
                    // Add item, also add in dictionary even if it doesn't stack
                    itemsCollected.Add(item);
                    countStack[item.itemName] = currentCount + 1;
                    Debug.Log($"{item.name} added to {category} inventory.");
                }
                else if (!uniqueItems)
                {
                    // Add item, also add in dictionary even if it doesn't stack
                    itemsCollected.Add(item);
                    countStack[item.itemName] = currentCount + 1;
                    Debug.Log($"{item.name} added to {category} inventory.");
                }
            }
        }
        else
        {
            Debug.LogWarning("Item can't be added to Inventory, it may have full slots, full stack of that item or is a Unique inventory and the item is already collected");
        }

        
    }

    void UpdateDictionary()
    {
        //Populate countStack from itemsCollected list to initialize the inventory stacks if items stack
        countStack.Clear();
        foreach (var item in itemsCollected)
        {
            if (countStack.ContainsKey(item.itemName))
                countStack[item.itemName]++;
            else
                countStack[item.itemName] = 1;

            if (countStack.TryGetValue(item.itemName, out int stackCount))
            {
                Debug.Log($"{item.itemName} = {stackCount}");
            }
            else
            {
                Debug.LogWarning($"Item '{item.itemName}' not found in countStack.");
            }

        }


    }
}

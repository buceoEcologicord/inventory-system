using NUnit.Framework;
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
    [SerializeField] public bool itemsStack = true;
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

    public override bool TryAddToInventory(Item item)
    {
        UpdateDictionary();

        bool hasStack = countStack.ContainsKey(item.itemName);
        int currentStack = hasStack ? countStack[item.itemName] : 0;
        //if (hasStack) //To debug countStack
        //{
        //    Debug.Log("countStack in GI: " + countStack[item.itemName]);
        //}
        int totalItems = itemsCollected.Count;
        int totalSlots = itemsStack ? countStack.Count : itemsCollected.Count;       

        bool underTotalItemLimit = unlimitedTotalItems || totalItems < maxTotalItems;
        bool underSlotLimit = unlimitedTotalItems || totalSlots < maxTotalSlots;
        bool canExtendStack = hasStack && (unlimitedStack || currentStack < itemStackLimit);
        bool canCreateNewStack = !hasStack && underSlotLimit;

        // Reject if we’ve already hit the total-item limit
        if (!underTotalItemLimit)
            return false;

        if (itemsStack)
        {
            // Unique-stacks only allow one instance
            if (uniqueItems && hasStack)
                return false;

            // Try to add into an existing stack
            if (hasStack && canExtendStack)
            {
                Debug.Log("item countStack in GI before AddToInventory: " + countStack[item.itemName]);

                AddToInventory(item);
                Debug.Log("item countStack in GI after AddToInventory: " + countStack[item.itemName]);

                Debug.Log("hasStack && canExtendStack");
                return true;
            }

            // Or open a brand-new stack
            if (!hasStack && canCreateNewStack)
            {
                AddToInventory(item);
                Debug.Log("!hasStack && canCreateNewStack");
                return true;
            }

            // Otherwise, no valid move
            return false;
        }
        else // no stacking: each item consumes one slot
        {
            // Unique items only allow one slot per type
            if (uniqueItems && hasStack)
                return false;

            // Need an empty slot to add
            if (underSlotLimit)
            {
                AddToInventory(item);
                Debug.Log("underSlotLimit");
                Debug.Log($"UnlimitedTotalItems {unlimitedTotalItems}");
                Debug.Log($"current slots {totalSlots}, max slots {maxTotalSlots}");

                return true;
            }

            return false;
        }
        ///<summary>
        /// Old conditional code kept just in case
        ///  
        ///
        ///
        ///
        /// Adds all items if total items are unlimited, as long as it's not unique items and item is already collected
        ///if (unlimitedTotalItems)
        ///{
        ///    // Check if item is unique and already exists in the inventory or if the inventory has no limit
        ///    if ((uniqueItems && !hasItem))
        ///    {
        ///        // Add item and stack
        ///        AddToInventory(item);
        ///        return true;
        ///    }
        ///    else if (!uniqueItems)
        ///    {
        ///        // Add item and stack
        ///        AddToInventory(item);
        ///        return true;
        ///    }
        ///
        /// Debug.LogWarning("Not added to inventory: Is repeated Unique");
        /// return false;
        ///
        ///}        
        ///else if (itemsCollected.Count < maxTotalItems) // Check if inventory is not full
        ///{
        ///    if (itemsStack)
        ///    {
        ///        if (uniqueItems && !hasItem)
        ///        {
        ///            if (unlimitedStack && countStack.Count < maxTotalSlots)
        ///            {
        ///                // Add item and stack
        ///                AddToInventory(item);
        ///                return true;
        ///            }
        ///            else if (unlimitedStack && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
        ///            {
        ///                // Add item and stack
        ///                AddToInventory(item);
        ///                return true;
        ///            }
        ///            else if (currentCount < itemStackLimit && countStack.Count < maxTotalSlots)
        ///            {
        ///                // Add item and stack
        ///                AddToInventory(item);
        ///                return true;
        ///            }
        ///            else if (currentCount < itemStackLimit && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
        ///            {
        ///                // Add item and stack
        ///                AddToInventory(item);
        ///                return true;
        ///            }
        ///
        ///            Debug.LogWarning("Not added to inventory: Is repeated Unique or slots are full, or stacks are full or inventory limit reached");
        ///            return false; 
        ///
        ///        }
        ///        else if (!uniqueItems)
        ///        {
        ///            if (unlimitedStack && countStack.Count < maxTotalSlots)
        ///            {
        ///                // Add item and stack
        ///                AddToInventory(item);
        ///                return true;
        ///            }
        ///           else if (unlimitedStack && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
        ///          {
        ///             // Add item and stack
        ///            AddToInventory(item);
        ///           return true;
        ///      }
        ///     else if (currentCount < itemStackLimit && countStack.Count < maxTotalSlots)
        ///    {
        ///       // Add item and stack
        ///      AddToInventory(item);
        ///     return true;
        ///            }
        ///            else if (currentCount < itemStackLimit && countStack.Count == maxTotalSlots && countStack.ContainsKey(item.itemName))
        ///            {
        ///               // Add item and stack
        ///              AddToInventory(item);
        ///             return true;
        ///        }
        ///   }
        ///
        ///       Debug.LogWarning("Not added to inventory: Slots are full, or stacks are full or inventory limit reached");
        ///      return false;
        ///
        ///   }
        ///  else if (itemsCollected.Count < maxTotalSlots)
        /// {
        ///    if (uniqueItems && !hasItem)
        ///   {
        ///      // Add item, also add in dictionary even if it doesn't stack
        ///     AddToInventory(item);
        ///    return true;
        /// }
        ///        else if (!uniqueItems)
        ///        {
        ///            // Add item, also add in dictionary even if it doesn't stack
        ///            AddToInventory(item);
        ///           return true;
        ///      }
        /// }
        ///
        ///    Debug.LogWarning("Not added to inventory: Repeated Unique item or Slots are full");
        ///    return false;
        ///
        /// }
        /// else
        /// {
        ///    Debug.LogWarning("Item can't be added to Inventory, it may have full slots, full stack of that item or is a Unique inventory and the item is already collected");
        ///    return false;
        ///}
        /// </summary>
    }

}

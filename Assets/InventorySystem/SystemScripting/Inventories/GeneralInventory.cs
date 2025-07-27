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

    }

}

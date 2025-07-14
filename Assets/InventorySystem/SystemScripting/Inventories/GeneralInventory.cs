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
    [SerializeField] private bool unlimitedSlots = false;
    [SerializeField] private bool itemsStack = true;
    [SerializeField] private bool unlimitedStack = false;
    [SerializeField] private int maxTotalSlots = 20;
    [SerializeField] private int itemStackLimit = 20;
    [SerializeField] private int maxTotalItems = 100;

    // When enabled organize inventory items into stacks to know how mamny slots there are occupied
    private void OnEnable()
    {
        //Populate countStack from itemsCollected list to initialize the inventory stacks if items stack
        countStack.Clear();
        foreach (var item in itemsCollected)
        {
            if (countStack.ContainsKey(item.itemName))
                countStack[item.itemName]++;
            else
                countStack[item.itemName] = 1;
        }
    }

    public void AddToInventory(Item item)
    {
        if (countStack.Count < maxTotalSlots || countStack[item.itemName] < itemStackLimit || unlimitedSlots || unlimitedStack)
        {
            if(uniqueItems && itemsCollected.Contains(item))
            {
                Debug.LogWarning("Item already exists in the inventory and this inventory is set to not repeat items! Unncheck Unique Items to avoid this");
                return;
            }

            if (itemsStack && (countStack[item.itemName] < itemStackLimit || unlimitedStack))
            {
                itemsCollected.Add(item);

                if (itemsCollected.Contains(item))
                {
                    countStack[item.itemName]++;                                       
                }
                else
                {
                    countStack[item.itemName] = 1;
                }
            }
            else if(!itemsCollected.Contains(item) && (countStack.Count < maxTotalSlots || unlimitedSlots))
            {
                itemsCollected.Add(item);
            }
        }
        else
        {
            Debug.LogWarning("Inventory is full!");
        }
    }
}

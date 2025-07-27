using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add (future: or remove) items to inventory received through events and destroy the gameObjects if applies
/// 
/// REMEMBER: Add ListOfGameObjectsListener and setup when event detected to call AddItemsFromList()
/// </summary>


// Set itemEventListener and
// Listener to activate all functionalities
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Inventory> inventories = new List<Inventory>();    

    // Used to add items via Event System, using ListOfGameObjectsEvent to add items in bulk in case many objects are in range
    public void AddItemsFromList(List<GameObject> collectiblesInRange)
    {

        //Reverse loop to allow changig a list while iterating through it
        for (int i = collectiblesInRange.Count - 1; i >= 0; i--)
        {
            if(AddItemToCorrectInventory(collectiblesInRange[i].GetComponentInChildren<CollectibleItem>().collectibleItem))
            {
                Destroy(collectiblesInRange[i]);
            }

        }
            collectiblesInRange.Clear();
    }
    public bool AddItemToCorrectInventory(Item item)
    {
        //Gets the correct Inventory from the inventories list of this manager based on a match of inventory/item category
        Inventory target = inventories.Find(inv => inv.category == item.itemCategory);

        //If item category matches an inventory category from the list of inventories it adds item to it, else it doesn't
        if (target != null)
        {
            return target.TryAddToInventory(item);
        }
        else
        {
            Debug.LogWarning($"No inventory found for category: {item.itemCategory}");
            return false;
        }
    }
}

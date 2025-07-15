using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add (future: or remove) items to inventory received through events and destroy the gameObjects if applies
/// </summary>
 

// Set itemEventListener and boolEventListener to activate all functionalities
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Inventory> inventories = new List<Inventory>();    

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
        Inventory target = inventories.Find(inv => inv.category == item.itemCategory);
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

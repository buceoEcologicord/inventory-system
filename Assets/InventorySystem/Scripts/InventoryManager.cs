using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Inventory> inventories = new List<Inventory>();

    public void AddItemToCorrectInventory(Item item)
    {
        Inventory target = inventories.Find(inv => inv.category == item.itemCategory);
        if (target != null)
        {
            target.AddToInventory(item);
        }
        else
        {
            Debug.LogWarning($"No inventory found for category: {item.itemCategory}");
        }
    }
}

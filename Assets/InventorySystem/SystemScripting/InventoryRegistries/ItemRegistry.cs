using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "ItemRegistry", menuName = "Inventory/Item Registry")]
public class ItemRegistry : ScriptableObject
{
    [SerializeField] public List<Item> allItems;

    public Item GetItemByID(string id)
    {
        return allItems.FirstOrDefault(item => item.ItemID == id);
    }

    public List<string> GetAllItemIDs() =>
        allItems.Select(i => i.ItemID).ToList();
}
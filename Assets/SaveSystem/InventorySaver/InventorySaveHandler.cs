using UnityEngine;
using ScriptableObjects.Events;

public class InventorySaveHandler : MonoBehaviour
{
    [Tooltip("Drag in every Inventory SO you want persisted")]
    [SerializeField] private Inventory[] inventories;
    [SerializeField] private VoidListener voidListener;
    [SerializeField] private ItemRegistry itemRegistry;

    // Used as a resource to make a valid Unity process
    Void n;

    private void Awake()
    {
        foreach (var inv in inventories)
        {
            // Immediately load from disk
            LoadInventory(inv);
            // Subscribe to the ScriptableObject event
            inv.OnInventoryChanged.AddListener(OnInventoryChanged(n));

            
        }
    }

    private void OnDestroy()
    {
        foreach (var inv in inventories)
            inv.OnInventoryChanged.RemoveListener(OnInventoryChanged(n));
    }

    public VoidListener OnInventoryChanged(Void n)
    {
        // Find which inventory raised the event
        // (VoidEvent doesn't tell us which one, so we save all)
        foreach (var inv in inventories)
            SaveInventory(inv);
        return voidListener;
    }

    public void SaveInventory(Inventory inv)
    {
        var data = new InventorySaveData
        {
            itemNames = inv.itemsCollected.ConvertAll(i => i.itemName),
            countStack = inv.countStack
        };

        SaveLoadService.Save(data, $"inventory_{inv.inventoryName}.json");
    }

    private void LoadInventory(Inventory inv)
    {
        var data = SaveLoadService.Load<InventorySaveData>($"inventory_{inv.inventoryName}.json");
        if (data == null) return;

        foreach (var ID in data.itemNames)
        {
            // You need some lookup by ID—e.g. a ScriptableObject library in scene
            var item = itemRegistry.GetItemByID(ID);
            if (item != null)
                inv.AddToInventory(item);
            else
                Debug.LogWarning($"[Load] '{ID}' not found in registry");
        }
    }
}

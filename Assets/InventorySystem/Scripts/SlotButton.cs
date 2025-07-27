using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Add this script to a GameObject to assign to it an item 
/// that can be collected in an inventory.
/// </summary>

public class SlotButton : MonoBehaviour, IPointerClickHandler
{
    public int itemIndex; // Item to be set by InventoryUIManager
    Inventory inventory;

    private void Start()
    {
        inventory = GetComponentInParent<InventoryUIManager>().inventory;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(inventory != null) 
            inventory.RemoveFromInventory(itemIndex);
    }
}

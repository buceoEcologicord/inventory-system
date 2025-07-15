using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryDisplay : MonoBehaviour
{
    public TextMeshProUGUI inventoryDisplay;
    public List< Inventory> inventories = new List<Inventory>();

    public void DisplayInventory()
    {
        
            string displayText = ""; // Initialize an empty string to build the display

            foreach (Inventory inventory in inventories)
            {
                displayText += "\n" + inventory.name + "\n";
                foreach (Item item in inventory.itemsCollected)
                displayText += item.itemName + "\n"; // Append the collectible's name and a newline character
            }

            inventoryDisplay.text = displayText; // Set the TextMeshPro text to the built string
        
    }
}

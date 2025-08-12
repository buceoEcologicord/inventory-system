using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 
/// 
/// REMEMBER: Add OnInventoryChangedListener and setup to call UpdateInventory()
/// </summary>

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventorySlot; //Prefab to display and manipulate inventory item containd in a slot
    public Transform gridParent; //Add grid component to game object to create in order the desired amount of slots
    public GeneralInventory inventory; //TEST: if can be changed by Inventory type instead
    public List< Item> itemsCollected; //To manage internally the items already in an inventory
    //Remember: to set up an OnInventoryChanged eventlistener that calls UpdateInventoryUI()

    public List<string> itemsCreated = new List<string>(); //Keeps track of item stacks that already exists to add a new item to the correct stack
    public List<GameObject> slotsCreated = new List<GameObject>(); //Keeps track of slots stacks that already exists to add a new item to the correct stack


    public void UpdateInventoryUI()
    {
        inventory.UpdateDictionary(); //Updates the inventory dictionary, helps prevent errors if inventory.itemsCollected() changed without triggering this Method (through an event for example)
        
        itemsCollected = inventory.itemsCollected; // Gets items present in enventory and updates the local list to manage items

        if(inventory.itemsStack)
        {            
            RefreshUI();
            foreach (var itemName in inventory.stackOrder)
            {
                Item targetItem = itemsCollected.Find(item => item.itemName == itemName);
                int targetIndex = itemsCollected.IndexOf(targetItem);
                
                CreateSlot(targetItem, targetIndex);                                   
            }
        }
        else
        {
            RefreshUI();

            int index = -1;
            foreach (Item item in itemsCollected)
            {
                index++;

                CreateSlot(item, index);
            }
        }                       
    }

    private void CreateSlot(Item item, int index)
    {
        GameObject createdSlot = (Instantiate(inventorySlot, gridParent));
        slotsCreated.Add(createdSlot);
        createdSlot.SetActive(true);
        createdSlot.GetComponent<Image>().sprite = item.sprite;
        createdSlot.GetComponent<SlotButton>().itemIndex = index;
        itemsCreated.Add(item.itemName);

        if (inventory.itemsStack)
        { createdSlot.GetComponentInChildren<TextMeshProUGUI>().text = $"{inventory.countStack[item.itemName]}"; }
    }

    private void RefreshUI()
    {
        for (int i = slotsCreated.Count - 1; i >= 0; i--)
        {            
                Destroy(slotsCreated[i]);
        }

        slotsCreated.Clear();
        itemsCreated.Clear();        
    }    
}

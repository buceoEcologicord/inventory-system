using ScriptableObjects.Events;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
        
        itemsCollected = inventory.itemsCollected; // Gets items present in enventory and updates the local list to manage items

        if(inventory.itemsStack)
        {
            //Debug.Log("ItemStack: true");
            ClearEmptySlots();

            int index = -1;

            foreach (Item item in itemsCollected)
            {
                index++;
                //Debug.Log($"ForEach item: {item.itemName}");

                if (!itemsCreated.Contains(item.itemName))
                {  
                    //Debug.Log($"ìtemsCreated not contains {item.itemName}");
                    
                    GameObject createdSlot = (Instantiate(inventorySlot, gridParent));
                    slotsCreated.Add(createdSlot);
                    createdSlot.SetActive(true);
                    createdSlot.GetComponent<Image>().sprite = item.sprite;
                    createdSlot.GetComponent<SlotButton>().itemIndex = index;
                    itemsCreated.Add(item.itemName);
                    createdSlot.GetComponentInChildren<TextMeshProUGUI>().text = $"{inventory.countStack[ item.itemName]}";
                    
                }
                else
                {
                    //Debug.Log($"itemsCreated contains {item.itemName}");
                    int itemsCreatedIndex = itemsCreated.IndexOf(item.itemName);

                    //Debug.Log($"index: {index}");
                    inventory.UpdateDictionary();
                    string text = $"{inventory.countStack[item.itemName]}";

                    //Debug.Log($"index: {index}, text: {text}");

                    slotsCreated[itemsCreatedIndex].GetComponentInChildren<TextMeshProUGUI>().text = text;
                }               
            }
        }
        else
        {
            RefreshUI();
                int index = -1;
            foreach (Item item in itemsCollected)
            {
                index++;

                Debug.Log($"START UDATE FOR ITEM: {item.itemName}");
                
                GameObject createdSlot = Instantiate(inventorySlot, gridParent);
                Debug.Log($"Created slot: {createdSlot.name}");
                slotsCreated.Add(createdSlot);
                Debug.Log("added to slotsCreated");
                createdSlot.SetActive(true);
                Debug.Log("Set active");
                createdSlot.GetComponent<Image>().sprite = item.sprite;
                Debug.Log("sprite assigned");
                createdSlot.GetComponent<SlotButton>().itemIndex = index;
                itemsCreated.Add(item.itemName);
                Debug.Log("added to items created");
                Debug.Log($"FINISH UPDATE FOR ITEM: {item.itemName}");
            }
        }
                       
    }

    private void RefreshUI()
    {
        Debug.Log("RefreshUI entered");

        for (int i = slotsCreated.Count - 1; i >= 0; i--)
        {
            
                Destroy(slotsCreated[i]);
                Debug.Log("Destroyed succesfully");
            }
            Debug.Log("Clear lists");
            slotsCreated.Clear();
            itemsCreated.Clear();
        
    }

    private void ClearEmptySlots()
    {
        for (int i = slotsCreated.Count - 1; i >= 0; i--)
        {
            var slot = slotsCreated[i];
            //Debug.Log($"SlotCreated: {slotsCreated[i].name}");
            //Debug.Log($"Slot item name: {slot.GetComponent<SlotButton>().item.itemName}");
            Debug.Log(slot.GetComponent<SlotButton>().itemIndex);
            if(slot.GetComponent<SlotButton>().itemIndex > 0 && slot.GetComponent<SlotButton>().itemIndex < slotsCreated.Count)
            {
                var itemName = itemsCollected[slot.GetComponent<SlotButton>().itemIndex].itemName;

                if (!inventory.countStack.ContainsKey(itemName))
                {
                    //Debug.Log("slot is empty");
                    slotsCreated.RemoveAt(i);
                    itemsCreated.Remove(itemName);
                    Destroy(slot);
                }

            }
            else
            {
                slotsCreated.Clear();
                itemsCreated.Clear();
                Destroy(slot);
            }

            
        }

    }
}

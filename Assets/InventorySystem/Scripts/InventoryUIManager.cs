using ScriptableObjects.Events;
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
    public VoidEvent OnInventoryChanged; //To update UI everytime inventory is changed
    //Remember: to set up an event listener that calls UpdateInventoryUI()

    public List<string> itemsCreated = new List<string>(); //Keeps track of item stacks that already exists to add a new item to the correct stack
    public List<GameObject> slotsCreated = new List<GameObject>(); //Keeps track of slots stacks that already exists to add a new item to the correct stack

   

    public void UpdateInventoryUI()
    {
        itemsCollected = inventory.itemsCollected; // Gets items present in enventory and updates the local list to manage items

        if(inventory.itemsStack)
        {
            Debug.Log("ItemStack: true");

            

            foreach (Item item in itemsCollected)
            {
                Debug.Log($"ForEach item: {item.itemName}");

                if (!itemsCreated.Contains(item.itemName))
                {  
                    Debug.Log($"ìtemsCreated not contains {item.itemName}");
                    
                    GameObject createdSlot = (Instantiate(inventorySlot, gridParent));
                    slotsCreated.Add(createdSlot);
                    createdSlot.SetActive(true);
                    createdSlot.GetComponent<Image>().sprite = item.sprite;
                    createdSlot.GetComponent<SlotButton>().item = item;
                    itemsCreated.Add(item.itemName);
                    createdSlot.GetComponentInChildren<TextMeshProUGUI>().text = $"{inventory.countStack[ item.itemName]}";
                    
                }
                else
                {
                    Debug.Log($"itemsCreated contains {item.itemName}");
                    int index = itemsCreated.IndexOf(item.itemName);

                    Debug.Log($"index: {index}");
                    inventory.UpdateDictionary();
                    string text = $"{inventory.countStack[item.itemName]}";

                    Debug.Log($"index: {index}, text: {text}");

                    slotsCreated[index].GetComponentInChildren<TextMeshProUGUI>().text = text;
                }               
            }
        }
        else
        {
            foreach (Item item in itemsCollected)
            {
                Instantiate(inventorySlot, gridParent);
                inventorySlot.SetActive(true);
                inventorySlot.GetComponent<Image>().sprite = item.sprite;
            }
        }
                       
    }
}

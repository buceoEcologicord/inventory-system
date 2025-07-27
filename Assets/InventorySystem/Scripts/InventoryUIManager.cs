using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventorySlot;
    public Transform gridParent;
    public GeneralInventory inventory;
    public List< Item> itemsCollected;

    public List<string> itemsCreated = new List<string>();
    public List<GameObject> slotsCreated = new List<GameObject>();


    public void UpdateInventoryUI()
    {
        itemsCollected = inventory.itemsCollected;

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

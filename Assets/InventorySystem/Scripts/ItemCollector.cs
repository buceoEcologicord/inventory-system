using ScriptableObjects.Events;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Add this component to player object in hierarchy to collect items
/// when you collide them or press a button while in range.
/// 
/// Passes the container gameobject to the inventory manager who decides what to do.
/// 
/// Is here instead of using Inventory manager to allow inventory manager 
/// to manage inventories outside the player prefab  
/// i.e to manage inventories from different player characters or other circumstances
/// </summary>

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private GameObject interactionSign;
    [SerializeField] private BoolEvent boolEvent;
    [SerializeField] private ListOfGameObjectEvent listOfGameObjectEvent;
    [SerializeField] private bool collectOnContact;

    private List<GameObject> collectiblesGameObjects = new List<GameObject>();

    /// <summary>
    /// Colelct on contact or through button sent on enable in case
    /// two different collectors switch betwen each other to change
    /// this condition depending on the game moment
    /// </summary>

    private void Start()
    {
        interactionSign.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.GetComponentInChildren<CollectibleItem>())
        {
            collectiblesGameObjects.Add(collision.gameObject);

            if (collectOnContact)
            {
                listOfGameObjectEvent.Raise(collectiblesGameObjects);                 
            }
            else
            {
                interactionSign.gameObject.SetActive(true);                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInChildren<CollectibleItem>())
        {
            collectiblesGameObjects.Remove(collision.gameObject);
        }


        if (collectiblesGameObjects.Count == 0)
        {
            interactionSign.gameObject.SetActive(false);            
        }
    }

    public void OnInteract()
    {
        listOfGameObjectEvent.Raise(collectiblesGameObjects);        
    }    
}

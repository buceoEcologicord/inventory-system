using UnityEngine;

/// <summary>
/// Add this script to a GameObject to assign to it an item 
/// that can be collected in an inventory.
/// </summary>

public class CollectibleItem : MonoBehaviour
{    
    [SerializeField] public Item collectibleItem;
}

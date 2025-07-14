using UnityEngine;

/// <summary>
/// Inherit childs from this class to create items that 
/// can be used in the inventory system as Items Types.
/// E.g. Weapons, Potions, Materials, etc.
/// </summary>

public abstract class Item : ScriptableObject 
{
    [SerializeField] public string itemName = "Item";
    [SerializeField] public Sprite sprite;
    [SerializeField] public bool stackable = true;

    [TextArea(3, 10)]
    [SerializeField] private string description = "Item function and characteristics are: ";
}
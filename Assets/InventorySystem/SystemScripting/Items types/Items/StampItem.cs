using UnityEngine;

[CreateAssetMenu(fileName = "StampItem", menuName = "Items/Stamp")]
public class StampItem : Item
{
    [SerializeField] public Sprite stampSprite;
    [SerializeField] public string stampLocation = "Map location";

}

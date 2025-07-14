using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu(fileName = "StampItem", menuName = "Items/Stamp")]
public class StampItem : Item
{
    [SerializeField] public Sprite stampSprite;
    [SerializeField] public enum StampRarity
        {
        common,
        uncommon,
        rare,
    };

}

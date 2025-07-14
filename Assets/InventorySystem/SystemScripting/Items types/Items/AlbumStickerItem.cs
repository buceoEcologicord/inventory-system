using UnityEngine;

[CreateAssetMenu(fileName = "AlbumStickerItem", menuName = "Items/Album Sticker")]
public class AlbumStickerItem : Item
{
    [SerializeField] public Sprite albumStickerSprite;
    [SerializeField] public enum StampRarity
        {
        common,
        uncommon,
        rare,
    };

}

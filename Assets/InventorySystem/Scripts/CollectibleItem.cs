using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// Add this script to a GameObject to assign to it an item 
/// that can be collected in an inventory.
/// </summary>

public class CollectibleItem : MonoBehaviour
{    
    [SerializeField] public Item collectibleItem;

    private SpriteRenderer spriteRenderer;
    private Sprite sprite;

    private void Start()
    {
        sprite = collectibleItem.sprite;
        if (sprite != null)
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }
    }
}

using ScriptableObjects.Events;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private CollectibleItem potionItem;
    [SerializeField] private CollectibleItem stampItem;
    [SerializeField] private CollectibleItem albumStickerItem;
    [SerializeField] private ItemEvent itemGameEvent;
    public void OnInteract()
    {
        itemGameEvent.Raise(potionItem.collectibleItem);
        itemGameEvent.Raise(stampItem.collectibleItem);
        itemGameEvent.Raise(albumStickerItem.collectibleItem);
    }

}

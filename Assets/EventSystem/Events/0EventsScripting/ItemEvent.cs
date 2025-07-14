using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Item Event", menuName = "Game Events/Item")]
    public class ItemEvent : BaseGameEvent<Item> { }
}

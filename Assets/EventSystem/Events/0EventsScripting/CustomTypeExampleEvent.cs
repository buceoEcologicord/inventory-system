using UnityEngine;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "CustomTypeExample Event", menuName = "Game Events/CustomTypeExample")]
    public class CustomTypeExampleEvent : BaseGameEvent<CustomTypeExample> { }
}

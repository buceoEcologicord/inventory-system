using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Events
{
    [System.Serializable] public class UnityListOfGameObjectEvent : UnityEvent<List<GameObject>> { }
}
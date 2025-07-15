using UnityEngine;
using System.Collections.Generic;

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "ListOfGameObject Event", menuName = "Game Events/List Of Game Object")]
    public class ListOfGameObjectEvent : BaseGameEvent<List<GameObject>> { }
}

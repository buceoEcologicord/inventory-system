using UnityEngine;

//Based on Dapper Dino Scriptable Object Event System
//https://www.youtube.com/watch?v=iXNwWpG7EhM
//https://www.youtube.com/watch?v=P-U7GPXMtLY

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Int Event", menuName = "Game Events/Int")]
    public class IntEvent : BaseGameEvent<int> { }
}

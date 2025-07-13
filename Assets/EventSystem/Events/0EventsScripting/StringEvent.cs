using UnityEngine;

//Based on Dapper Dino Scriptable Object Event System
//https://www.youtube.com/watch?v=iXNwWpG7EhM
//https://www.youtube.com/watch?v=P-U7GPXMtLY

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "String Event", menuName = "Game Events/String")]
    public class StringEvent : BaseGameEvent<string> { }
}

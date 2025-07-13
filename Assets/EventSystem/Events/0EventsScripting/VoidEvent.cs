using UnityEngine;

//Based on Dapper Dino Scriptable Object Event System
//https://www.youtube.com/watch?v=iXNwWpG7EhM
//https://www.youtube.com/watch?v=P-U7GPXMtLY

namespace ScriptableObjects.Events
{
    [CreateAssetMenu(fileName = "Void Event", menuName = "Game Events/Void")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}

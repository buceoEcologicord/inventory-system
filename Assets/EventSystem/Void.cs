
//Based on Dapper Dino Scriptable Object Event System
//https://www.youtube.com/watch?v=iXNwWpG7EhM
//https://www.youtube.com/watch?v=P-U7GPXMtLY

namespace ScriptableObjects.Events
{
    //Used as a trick since our event system can't pass a void reference we're creating an artificial reference to pass with no data that has the same effect as being void but can be passed by the system
    [System.Serializable] public struct Void { }
}

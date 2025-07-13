using UnityEngine;
using ScriptableObjects.Events;

public class EventReceiver : MonoBehaviour
{
    public void DebugEventData(int receivedData) =>
        Debug.Log($"Received IntEvent Data: {receivedData}");
    
    public void DebugEventData(float receivedData) =>
        Debug.Log($"Received FloatEvent Data: {receivedData}");   
    
    public void DebugEventData(bool receivedData) =>
        Debug.Log($"Received boolEvent Data: {receivedData}");
    
    public void DebugEventData(string receivedData) =>
        Debug.Log($"Received StringEvent Data: {receivedData}");
    
    public void DebugEventData() =>
        Debug.Log($"Received VoidEvent");

    public void DebugEventData(CustomTypeExample receivedData) =>
        Debug.Log($"Received CustomTypeExampleEvent Data: Int {receivedData.customIntValue}, Float {receivedData.customFloatValue}, Bool {receivedData.customBoolValue}, String {receivedData.customSringValue}");    

}

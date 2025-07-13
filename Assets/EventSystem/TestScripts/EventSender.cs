using ScriptableObjects.Events;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EventSender : MonoBehaviour
{
    //public DataGameEvent dataGameEvent;
    //public EventData eventData;

    [Header("Events")]
    [SerializeField] private IntEvent intEventTest;
    [SerializeField] private FloatEvent floatEventTest;
    [SerializeField] private BoolEvent boolEventTest;
    [SerializeField] private StringEvent stringEventTest;
    [SerializeField] private VoidEvent voidEventTest;
    [SerializeField] private CustomTypeExampleEvent customTypeExampleEventTest;

    [Header("Test values to pass on events")]
    [SerializeField] private int intTest = 5;
    [SerializeField] private float floatTest = 2.4f;
    [SerializeField] private bool boolTest = true;
    [SerializeField] private string stringTest = "Test string";
    [SerializeField] private CustomTypeExample customTypeExample;


    public void OnInteract()
    {
        //dataGameEvent.TriggerEvent(eventData);

        intEventTest.Raise(intTest);
        floatEventTest.Raise(floatTest);
        boolEventTest.Raise(boolTest);
        stringEventTest.Raise(stringTest);
        voidEventTest.Raise();
        customTypeExampleEventTest.Raise(customTypeExample);

    }
}

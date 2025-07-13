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

    [Header("Values from Variable References")]
    [SerializeField] private VariableReference<int> intVariable;
    [SerializeField] private VariableReference<float> floatVariable;
    [SerializeField] private VariableReference<bool> boolVariable;
    [SerializeField] private VariableReference<string> stringVariable;
    [SerializeField] private VariableReference<CustomTypeExample> CustomTypeExampleVariable;


    public void OnInteract()
    {
        //Trigger events to pass the test values from the inspector

        intEventTest.Raise(intTest);
        floatEventTest.Raise(floatTest);
        boolEventTest.Raise(boolTest);
        stringEventTest.Raise(stringTest);
        voidEventTest.Raise();
        customTypeExampleEventTest.Raise(customTypeExample);

        //Raise events using variable references
        intEventTest.Raise(intVariable.Value);
        floatEventTest.Raise(floatVariable.Value);
        boolEventTest.Raise(boolVariable.Value);
        stringEventTest.Raise(stringVariable.Value);
        customTypeExampleEventTest.Raise(CustomTypeExampleVariable.Value);
    }
}

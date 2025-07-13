using ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class VariablesTest : MonoBehaviour
{
    [SerializeField] private VariableReference<int> intReference;
    [SerializeField] private VariableReference<float> floatReference;
    [SerializeField] private VariableReference<bool> boolReference;
    [SerializeField] private VariableReference<string> stringReference;
    [SerializeField] private VariableReference<Vector3> vector3Reference;

    //Testing purposes only
    [SerializeField] private VariableReference<CustomTypeExample> customTypeExampleReference;


    void OnInteract()
    {
        Debug.Log($"String Reference: {intReference.Value}");
        Debug.Log($"String Reference: {floatReference.Value}");
        Debug.Log($"String Reference: {boolReference.Value}");
        Debug.Log($"String Reference: {stringReference.Value}");
        Debug.Log($"Vector3 Reference: {vector3Reference.Value}");

        //Is possible to reference a custom type with many variables of different types
        Debug.Log($"Custom Type Example Reference: {customTypeExampleReference.Value.customIntValue} {customTypeExampleReference.Value.customFloatValue} {customTypeExampleReference.Value.customBoolValue} {customTypeExampleReference.Value.customSringValue}");
    }
}

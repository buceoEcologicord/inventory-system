using UnityEngine;
using UnityEngine.InputSystem;

public class VariablesTest : MonoBehaviour
{
    [SerializeField] private VariableReference<int> intReference;
    [SerializeField] private VariableReference<float> floatReference;
    [SerializeField] private VariableReference<bool> boolReference;
    [SerializeField] private VariableReference<string> stringReference;
    [SerializeField] private VariableReference<Vector3> Vector3Reference;

    void OnInteract()
    {
        Debug.Log($"String Reference: {intReference.Value}");
        Debug.Log($"String Reference: {floatReference.Value}");
        Debug.Log($"String Reference: {boolReference.Value}");
        Debug.Log($"String Reference: {stringReference.Value}");
        Debug.Log($"Vector3 Reference: {Vector3Reference.Value}");
    }
}

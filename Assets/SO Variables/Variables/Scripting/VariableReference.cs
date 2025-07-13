using System;
using UnityEngine;

/// <summary>
/// Used to reference a specific variable or use a constant instead. 
/// This allows for flexibility when designing because it allows to quickly test
/// different values without changing the original variable which would affect all
/// instances that use it.
/// </summary>


[Serializable]
public class VariableReference<T>
{
    [SerializeField] private bool useConstant = true;
    [SerializeField] private T constantValue = default;
    [SerializeField] private Variable<T> variableAsset = default;

    public T Value => useConstant ? constantValue : variableAsset.Value;
}

using System;
using UnityEngine;

[Serializable]
public class VariableReference<T>
{
    [SerializeField] private bool useConstant = true;
    [SerializeField] private T constantValue = default;
    [SerializeField] private Variable<T> variableAsset = default;

    public T Value => useConstant ? constantValue : variableAsset.Value;
}

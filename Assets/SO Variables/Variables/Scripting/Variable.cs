using UnityEngine;

/// <summary>
/// Creates a base class for all variable types in the project
/// so all types can be referenced by just one VariableReference script 
/// instead of being a different script to reference each type./// 
/// </summary>

public abstract class Variable<T> : ScriptableObject
{
    public T Value;
}
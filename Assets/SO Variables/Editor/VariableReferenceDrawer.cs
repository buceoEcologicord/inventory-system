using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(VariableReference<>), true)]
public class VariableReferenceDrawer : PropertyDrawer
{
    private const float ToggleWidth = 20f;

    public override void OnGUI(Rect rect, SerializedProperty prop, GUIContent label)
    {
        var useConstProp = prop.FindPropertyRelative("useConstant");
        var constProp = prop.FindPropertyRelative("constantValue");
        var varProp = prop.FindPropertyRelative("variableAsset");

        rect = EditorGUI.PrefixLabel(rect, GUIUtility.GetControlID(FocusType.Passive), label);

        var toggleRect = new Rect(rect.x, rect.y, ToggleWidth, rect.height);
        var fieldRect = new Rect(rect.x + ToggleWidth, rect.y,
                                  rect.width - ToggleWidth, rect.height);

        EditorGUI.BeginProperty(rect, label, prop);
        EditorGUI.PropertyField(toggleRect, useConstProp, GUIContent.none);

        if (useConstProp.boolValue)
            EditorGUI.PropertyField(fieldRect, constProp, GUIContent.none);
        else
            EditorGUI.PropertyField(fieldRect, varProp, GUIContent.none);

        EditorGUI.EndProperty();
    }
}

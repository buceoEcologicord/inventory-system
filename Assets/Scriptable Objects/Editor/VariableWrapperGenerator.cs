using UnityEditor;
using System.IO;
using UnityEngine;

public class VariableWrapperGenerator : EditorWindow
{
    private string className = "MyTypeVariable";
    private string typeName = "float";
    private string menuPath = "Variables/";

    private Vector2 _scrollPos;
    private const string HelpText =
       "Use this tool if you created a new Type of variable to create a 'Wrapper' " +
        "that allows you to create the new Type of Scriptable Object Variable from the create menu. "; 

    [MenuItem("Variables/Variable Wrapper Generator")]
    public static void ShowWindow() =>
        GetWindow<VariableWrapperGenerator>("Variable Wrapper Gen");

    void OnGUI()
    {
        className = EditorGUILayout.TextField("Class Name", className);
        typeName = EditorGUILayout.TextField("Type Name", typeName);
        menuPath = EditorGUILayout.TextField("Menu Path", menuPath);

        if (GUILayout.Button("Generate Wrapper"))
        {
            var folder = "Assets/Scriptable Objects/Variables/Scripting";
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            var filePath = $"{folder}/{className}Variable.cs";
            var script =
$@"using UnityEngine;

[CreateAssetMenu(fileName = ""{className}Variable"", menuName = ""{menuPath}{className}"")]
public class {className}Variable : Variable<{typeName}> {{ }}
";

            File.WriteAllText(filePath, script);
            AssetDatabase.ImportAsset(filePath);
        }

        // Calculate height for ~10 lines of text
        float lineHeight = EditorGUIUtility.singleLineHeight;
        float padding = EditorGUIUtility.standardVerticalSpacing;
        float height = lineHeight * 5 + padding * 9;

        // Begin scroll area
        _scrollPos = EditorGUILayout.BeginScrollView(
            _scrollPos,
            GUILayout.Height(height)
        );

        GUIStyle whiteStyle = new GUIStyle(EditorStyles.textArea)
        {
            wordWrap = true,
            normal = { textColor = Color.white }
        };

        // Draw the text area (read‐only)
        EditorGUILayout.TextArea(
            HelpText,
            whiteStyle,
            GUILayout.ExpandHeight(true)
        );

        // End scroll area
        EditorGUILayout.EndScrollView();
        
    }
}

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(ItemRegistry))]
public class ItemRegistryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Validate & Assign Item IDs"))
        {
            var registry = (ItemRegistry)target;
            var allItems = registry.allItems; // Make sure this is a public or internal list

            HashSet<string> usedIDs = new HashSet<string>();

            for (int i = 0; i < allItems.Count; i++)
            {
                var item = allItems[i];
                if (item == null) continue;

                string newID = $"item_{i}";

                // Avoid overwriting with duplicate if item already shares the same ID
                if (!usedIDs.Contains(newID))
                {
                    Undo.RecordObject(item, "Update Item ID");
                    item.ItemID = newID;
                    EditorUtility.SetDirty(item);
                    usedIDs.Add(newID);
                }
            }

            Debug.Log("✅ All item IDs reassigned based on list position.");

            // Optional: revalidate uniqueness after assignment
            var duplicates = usedIDs.GroupBy(id => id)
                                    .Where(g => g.Count() > 1)
                                    .Select(g => g.Key)
                                    .ToList();

            if (duplicates.Count > 0)
                Debug.LogWarning($"⚠️ Duplicate item IDs still found: {string.Join(", ", duplicates)}");
        }
    }
}
#endif

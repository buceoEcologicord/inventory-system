using System.IO;
using UnityEngine;

public static class SaveLoadService
{
    public static void Save<T>(T data, string filename)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        string path = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllText(path, json);
        Debug.Log($"[Save] Wrote '{filename}' to: {path}");
    }

    public static T Load<T>(string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename);
        if (!File.Exists(path))
        {
            Debug.Log($"[Load] No file at: {path}");
            return default;
        }

        string json = File.ReadAllText(path);
        Debug.Log($"[Load] Read '{filename}' from: {path}");
        return JsonUtility.FromJson<T>(json);
    }
}

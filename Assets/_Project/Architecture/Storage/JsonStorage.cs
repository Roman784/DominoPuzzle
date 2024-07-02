using System;
using System.IO;
using UnityEngine;

public class JsonStorage : Storage
{
    public override GameData GameData { get; protected set; }

    private string _path;
    
    private JsonStorage()
    {
        BuildPath();
    }

    public override void Load(Action callback = null)
    {
        if (!File.Exists(_path))
        {
            Debug.Log("Load data error: file not exist");
            return;
        }

        try
        {
            using (var fileStream = new StreamReader(_path))
            {
                string json = fileStream.ReadToEnd();
                GameData = JsonUtility.FromJson<GameData>(json);
            }

            callback?.Invoke();

            Debug.Log("Load data complete");
        }
        catch { Debug.Log("Load data error"); }
    }

    public override void Save(Action callback = null)
    {
        try
        {
            using (var fileStream = new StreamWriter(_path))
            {
                string json = JsonUtility.ToJson(GameData, true);
                fileStream.Write(json);
            }

            callback?.Invoke();

            Debug.Log("Save data complete");
        }
        catch { Debug.Log("Save data error"); }
    }

    private void BuildPath()
    {
        #if UNITY_ANDROID && !UNITY_EDITOR
            _path = Path.Combine (Application.persistentDataPath, "gameData.json");
        #else
            _path = Path.Combine (Application.dataPath, "gameData.json");
        #endif
    }
}

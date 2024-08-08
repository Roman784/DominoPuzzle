using System;
using UnityEngine;

public class SDKStorage : Storage
{
    public override GameData GameData { get; protected set; }

    public override void Save()
    {
        try
        {
            string json = JsonUtility.ToJson(GameData, true);
            SDK.SaveData(json);
        }
        catch { Debug.Log("Save data error"); }
    }

    public override void Load(Action<bool> callback = null)
    {
        try
        {
            SDK.LoadData((string json) =>
            {
                GameData gameData = JsonUtility.FromJson<GameData>(json);

                if (gameData == null || json == null || json == "{}" || json == "")
                {
                    callback?.Invoke(false);
                }
                else
                {
                    GameData = gameData;
                    callback?.Invoke(true);
                }
            });
        }
        catch 
        { 
            Debug.Log("Load data error"); 
            callback?.Invoke(false);
        }
    }
}

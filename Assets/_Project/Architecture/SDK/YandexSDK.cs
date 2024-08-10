using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : SDK
{
    [DllImport("__Internal")] private static extern void InitYSDKExtern(int callbackId);
    [DllImport("__Internal")] private static extern void SaveDataExtern(string date);
    [DllImport("__Internal")] private static extern void LoadDataExtern();
    [DllImport("__Internal")] private static extern void ShowRewardedVideoExtern(int id);
    [DllImport("__Internal")] private static extern void ShowFullscreenAdvExtern();
    [DllImport("__Internal")] private static extern string GetLanguageExtern();
    [DllImport("__Internal")] private static extern void GameReadyExtern();

    private Dictionary<int, Action<bool>> _callbacksMap = new Dictionary<int, Action<bool>>();
    private Action<string> _jsonDataCallback;

    public override void Init(Action<bool> callback = null)
    {
        try 
        {
            int callbackId = RegisterCallback(callback);
            InitYSDKExtern(callbackId); 
        }
        catch  { callback?.Invoke(false); }
    }

    public override void SaveData(string data)
    {
        try { SaveDataExtern(data); }
        catch { Debug.Log("Save extern error"); }
    }

    public override void LoadData(Action<string> jsonCallback)
    {
        try 
        {
            _jsonDataCallback = jsonCallback;
            LoadDataExtern(); 
        }
        catch { Debug.Log("Load extern error"); }
    }

    public void AcceptLoadedData(string json)
    {
        _jsonDataCallback?.Invoke(json);
    }

    public override void ShowRewardedVideo(Action<bool> callback = null)
    {
        try
        {
            int id = RegisterCallback(callback);
            ShowRewardedVideoExtern(id);
        }
        catch { callback?.Invoke(false); }
    }

    public override void ShowFullscreenAdv()
    {
        try { ShowFullscreenAdvExtern(); }
        catch { Debug.Log("Full screen adv error"); }
    }

    public override Language GetLanguage()
    {
        try
        {
            string res = GetLanguageExtern();

            if (res == "ru")
                return Language.Ru;
            else
                return Language.En;
        }
        catch { return Language.En; }
    }

    public override void GameReady()
    {
        GameReadyExtern();
    }

    public void InvokeCallback(int id)
    {
        _callbacksMap[id]?.Invoke(true);
        _callbacksMap.Remove(id);
    }

    private int RegisterCallback(Action<bool> callback)
    {
        int id = 0;
        if (_callbacksMap.Count > 1)
            id = _callbacksMap.OrderByDescending(item => item.Key).First().Key + 1;
        _callbacksMap.Add(id, callback);

        return id;
    }
}

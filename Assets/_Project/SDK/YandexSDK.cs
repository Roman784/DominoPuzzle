using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : SDK
{
    [DllImport("__Internal")] private static extern void ShowRewardedVideoExtern(int id);

    private Dictionary<int, Action<bool>> _callbacksMap = new Dictionary<int, Action<bool>>();

    public override void Init()
    {
        Debug.Log("SDK init");
    }

    public override void ShowRewardedVideo(Action<bool> callback = null)
    {
        StopGame();

        try
        {
            int id = RegisterCallback(callback);
            ShowRewardedVideoExtern(id);
        }
        catch
        {
            callback?.Invoke(false);
            ContinueGame();
        }
    }

    public void OnRewarded(int id)
    {
        _callbacksMap[id]?.Invoke(true);
        _callbacksMap.Remove(id);

        ContinueGame();
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

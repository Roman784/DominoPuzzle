using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : ISDK
{
    [DllImport("__Internal")] private static extern void ShowRewardedVideoExtern();

    private YandexSDK()
    {
        GameObject receiver = new GameObject("YandexSDKReceiver", typeof(YandexSDKReceiver));
        GameObject.DontDestroyOnLoad(receiver);
    }

    public void ShowRewardedVideo(Action<bool> callback = null)
    {
        try
        {
            ShowRewardedVideoExtern();
        }
        catch
        {
            Debug.Log("Rewarded video error");
            callback?.Invoke(false);
        }
    }
}

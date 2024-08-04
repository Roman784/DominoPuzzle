using System;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

public class YandexSDK : ISDK
{
    [DllImport("__Internal")] private static extern void ShowRewardedVideoExtern();

    [Inject]
    private void Construct(AudioPlayer audioPlayer)
    {
        YandexSDKReceiver receiver = new GameObject("YandexSDKReceiver").AddComponent<YandexSDKReceiver>();
        GameObject.DontDestroyOnLoad(receiver.gameObject);

        receiver.Init(audioPlayer);
    }

    public void Init()
    {
        Debug.Log("SDK init");
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

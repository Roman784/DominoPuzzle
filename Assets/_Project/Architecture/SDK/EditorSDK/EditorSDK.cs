using System;
using UnityEngine;

public class EditorSDK : SDK
{
    public override void Init(Action<bool> callback = null) => callback?.Invoke(true);
    public override void SaveData(string data) { }
    public override void LoadData(Action<string> jsonCallback) { }
    public override void ShowRewardedVideo(Action<bool> callback = null) => callback?.Invoke(true);
    public override void ShowFullscreenAdv() { }
    public override Language GetLanguage() => Language.En;
    public override void GameReady() { }
}

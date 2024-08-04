using System;

public interface ISDK
{
    public void Init();
    public void ShowRewardedVideo(Action<bool> callback = null);
}

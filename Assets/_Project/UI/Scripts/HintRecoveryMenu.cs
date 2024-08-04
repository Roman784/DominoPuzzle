using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class HintRecoveryMenu : PanelMenu
{
    public UnityEvent OnRecovered = new UnityEvent();

    [Inject]
    private void Construct(CurrentTheme currentTheme)
    {
        TrySetColor(currentTheme.Config.MainColor);
    }

    public void Recover()
    {
        SDK.ShowRewardedVideo((bool res) =>
        {
            if (res)
                OnRecovered.Invoke();
        });
        ClosePanel();
    }
}

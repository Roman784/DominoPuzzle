using UnityEngine;
using Zenject;

public class Localization
{
    private SDK _SDK;

    [Inject]
    private void Construct(SDK SDK)
    {
        _SDK = SDK;
    }

    public void Init() { }

    public Language GetLanguage()
    {
        return _SDK.GetLanguage();
    }
}

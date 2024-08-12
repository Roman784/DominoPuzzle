using UnityEngine;
using Zenject;

public class SDKInstaller : MonoInstaller
{
    [SerializeField] private EditorSDK _editorSDK;
    [SerializeField] private YandexSDK _yandexSDK;

    public override void InstallBindings()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
            BindYandexSDK();
        else
            BindEditorSDK();
    }

    private void BindYandexSDK()
    {
        YandexSDK SDK = Instantiate(_yandexSDK, Vector2.zero, Quaternion.identity, null);
        Container.Bind<SDK>().FromInstance(SDK).AsSingle().NonLazy();

        DontDestroyOnLoad(SDK.gameObject);
        SDK.SetNameToToken();
    }

    private void BindEditorSDK()
    {
        EditorSDK SDK = Instantiate(_editorSDK, Vector2.zero, Quaternion.identity, null);
        Container.Bind<SDK>().FromInstance(SDK).AsSingle().NonLazy();
    }
}

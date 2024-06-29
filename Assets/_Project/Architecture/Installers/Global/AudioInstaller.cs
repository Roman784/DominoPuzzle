using UnityEngine;
using Zenject;

public class AudioInstaller : MonoInstaller
{
    [SerializeField] private AudioSourcer _sourcerPrefab; 

    public override void InstallBindings()
    {
        BindSorcerPrefab();
        BindPlayer();
    }

    private void BindSorcerPrefab()
    {
        Container.Bind<AudioSourcer>().FromInstance(_sourcerPrefab).AsTransient();
    }

    private void BindPlayer()
    {
        Container.Bind<AudioPlayer>().AsSingle();
    }
}

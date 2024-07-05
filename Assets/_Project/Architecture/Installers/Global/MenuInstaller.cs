using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private SceneNamesConfig _sceneNamesConfig;
    [SerializeField] private MenuSoundsConfig _soundsConfig;

    [SerializeField] private FieldCreationConfig _fieldCreationConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindOpeningLevelNumber();
    }

    private void BindConfigs()
    {
        Container.Bind<SceneNamesConfig>().FromInstance(_sceneNamesConfig).AsSingle();
        Container.Bind<MenuSoundsConfig>().FromInstance(_soundsConfig).AsSingle();

        Container.Bind<FieldCreationConfig>().FromInstance(_fieldCreationConfig).AsSingle();
    }

    private void BindOpeningLevelNumber()
    {
        Container.Bind<OpeningLevelNumber>().AsSingle();
    }
}

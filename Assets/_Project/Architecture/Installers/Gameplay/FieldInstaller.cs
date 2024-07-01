using UnityEngine;
using Zenject;

public class FieldInstaller : MonoInstaller
{
    [SerializeField] private FieldConfig _fieldConfig;
    [SerializeField] private FieldCreationConfig _fieldCreationConfig;
    [SerializeField] private FieldAnimationConfig _fieldAnimationConfig;
    [SerializeField] private FieldSoundConfig _fieldSoundConfig;

    public override void InstallBindings()
    {
        BindConfigs();
        BindFieldShuffling();
        BindField();
    }

    private void BindConfigs()
    {
        Container.Bind<FieldConfig>().FromInstance(_fieldConfig).AsSingle();
        Container.Bind<FieldCreationConfig>().FromInstance(_fieldCreationConfig).AsSingle();
        Container.Bind<FieldAnimationConfig>().FromInstance(_fieldAnimationConfig).AsSingle();
        Container.Bind<FieldSoundConfig>().FromInstance(_fieldSoundConfig).AsSingle();
    }

    private void BindFieldShuffling()
    {
        Container.Bind<IFieldShuffling>().To<FieldSwapShuffling>().AsSingle();
    }

    private void BindField()
    {
        Field prefab = _fieldCreationConfig.FieldPrefabsMap[0].Prefab;
        Container.Bind<Field>().FromComponentInNewPrefab(prefab).AsSingle().NonLazy();
    }
}

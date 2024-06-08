using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller
{
    [SerializeField] private Field _fieldPrefab;
    [SerializeField] private FieldSpawnConfig _fieldSpawnCOnfig;

    public override void InstallBindings()
    {
        BindField();
        //Container.Bind<>().To<>().AsSingle();
    }

    private void BindField()
    {
        Container.Bind<FieldSpawnConfig>().FromInstance(_fieldSpawnCOnfig);

        Field field = Container.InstantiatePrefabForComponent<Field>(_fieldPrefab);
        Container.BindInterfacesAndSelfTo<Field>().FromInstance(field).AsSingle();
    }
}

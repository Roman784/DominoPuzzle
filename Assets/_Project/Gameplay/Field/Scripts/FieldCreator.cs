using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class FieldCreator : MonoBehaviour
{
    private List<FieldPrefabItem> _fieldPrefabsMap;
    private Field _createdField;

    private DiContainer _diContainer;

    [Inject]
    private void Construct(DiContainer diContainer, FieldCreationConfig config, OpeningLevelNumber openingLevelNumber)
    {
        _diContainer = diContainer;
        _fieldPrefabsMap = config.FieldPrefabsMap;

        Create(openingLevelNumber.Number);
    }

    public Field CreatedField => _createdField;

    private void Create(int number)
    {
        Field prefab = _fieldPrefabsMap.FirstOrDefault(p => p.Number == number)?.Prefab;

        if (prefab == null)
            throw new KeyNotFoundException($"The field with number {number} was not found.");

        GameObject go = _diContainer.InstantiatePrefab(prefab);
        _createdField = go.GetComponent<Field>();
    }
}

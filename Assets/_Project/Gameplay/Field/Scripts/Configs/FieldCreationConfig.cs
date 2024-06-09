using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FieldCreationConfig", menuName = "Configs/Field/Creation")]
public class FieldCreationConfig : ScriptableObject
{
    [field: SerializeField] public List<FieldPrefabItem> FieldPrefabsMap {  get; private set; }

    private void OnValidate()
    {
        ValidateFieldNumbers();
    }

    // Checking for matching field numbers.
    private void ValidateFieldNumbers()
    {
        for (int i = 0; i < FieldPrefabsMap.Count; i++)
        {
            for (int j = i + 1; j < FieldPrefabsMap.Count; j++)
            {
                int number1 = FieldPrefabsMap[i].Number;
                int number2 = FieldPrefabsMap[j].Number;

                if (number1 == number2)
                    throw new Exception($"The field number {number1} already exists.");
            }
        }
    }
}
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class TextTranslator : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;
    [SerializeField] private string _tr;

    private Dictionary<Language, string> _translationsMap = new Dictionary<Language, string>();

    private TMP_Text _text;
    private Localization _localization;

    [Inject]
    private void Construct(Localization localization)
    {
        _text = GetComponent<TMP_Text>();
        _localization = localization;

        InitTranslationsMap();
        UpdateText();
    }

    private void InitTranslationsMap()
    {
        _translationsMap[Language.En] = _en;
        _translationsMap[Language.Ru] = _ru;
        _translationsMap[Language.Tr] = _tr;
    }

    private void UpdateText()
    {
        _text.text = _translationsMap[_localization.GetLanguage()];
    }
}
